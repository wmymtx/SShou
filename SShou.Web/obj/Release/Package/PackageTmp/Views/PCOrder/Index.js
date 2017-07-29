var $tableList = $("#orderList"), $datetimepicker = $('#datetimepicker'), $isRefresh = $("#isRefresh");

var orderStatusDic = {
    0: "待指派", 1: "已指派", 2: "已完成", "-1": "已撤销", 3: "已评分"
};

var $OrderAssign = $('#OrderAssign'), $OrderDetail = $("#OrderDetail"), $detail = $("#detail"), $orderList = $("#orderList"), $Assign = $("#Assign");
var _$form = $OrderAssign.find('form'), $enddatetimepicker = $("#enddatetimepicker");
var selectOrderId;


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {

        var date = new Date();
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var d = date.getFullYear() + "-" + (month < 10 ? "0" + month : month) + "-" + (day < 10 ? "0" + day : day);

        $tableList.bootstrapTable({
            url: '/PCOrder/GetOrderList',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: false,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "Id",                     //每一行的唯一标识，一般为主键列
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                field: 'Address',
                title: '地址'
                
            }, {
                    field: 'RecPhone',
                    title: '号码'
            }, {
                field: 'Status',
                title: '当前状态', formatter: function (value, row, index) {
                    return orderStatusDic[value];
                }
            }, {
                field: 'RecTime',
                title: '收货时间'
            }, {
                field: 'Remark',
                title: '备注'
            }, {
                align: 'center',
                field: '#',
                title: '查看详情', formatter: function (value, row, index) {
                    return '<p data-toggle="modal" orderId="' + row.Id + '" data-target="#OrderDetail" class="btn btn-info">订单详情</p>';
                }
            }, {
                align: 'center',
                field: '##',
                title: '派单', formatter: function (value, row, index) {
                    if (row.Status == 0)
                        return '<span data-toggle="modal" orderId="' + row.Id + '" data-target="#OrderAssign" class="btn btn-primary">订单指派</span>';
                    else
                        return '';
                }
            }], onLoadSuccess: function (data) {
                if (data.rows.length >= 1 && data.rows[0].Status==0)
                {
                    $('#chatAudio')[0].play();
                }
                $OrderAssign.on('shown.bs.modal', function () {
                    $OrderAssign.find('input:not([type=hidden]):first').focus();
                });
                $OrderDetail.on('shown.bs.modal', function () {

                    $OrderDetail.find('input:not([type=hidden]):first').focus();

                });

                $orderList.find('tr').find('p').on('click', function () {
                    console.log(this);
                    var orderId = $(this).attr('orderid');
                    console.log(orderId);
                    abp.ajax({
                        url: abp.appPath + 'Order/GetOrderDetail',
                        type: 'GET',
                        data: {
                            id: orderId
                        },
                        success: function (data) {
                            var orderItem = data.result.orderItems, order = data.result.order;
                            if (orderItem) {
                                var html = [];
                                for (var index = 0; index <= orderItem.length - 1; index++) {
                                    var html1 = '<tr><td>' + orderItem[index].productName + '</td><td>' + orderItem[index].productNum + '</td><td>' + orderItem[index].unit + '</td></tr>';
                                    html.push(html1);
                                }

                                $detail.html(html.join(''));
                            }
                        }
                    })
                });

                function bind() {
                    $(".userSelect").click(function (e) {
                        e.preventDefault();

                        var userId = $(this).attr("userId"), openId = $(this).attr('openId');

                        console.log(userId);
                        var content = $(this).parent().parent().find('td');
                        abp.ui.setBusy($OrderAssign);
                        abp.ajax({
                            url: abp.appPath + 'PCOrder/OrderAssign',
                            type: 'GET',
                            data: {
                                id: selectOrderId, ProsonId: userId, PersonName: content[0].innerHTML, PhoneNo: content[1].innerHTML, OpenId: openId
                            },
                            success: function (data) {
                                $OrderAssign.modal('hide');
                                location.reload(true);
                                //abp.ui.clearBusy($OrderAssign);
                            },
                            error: function () {
                                abp.ui.clearBusy($OrderAssign);
                            }
                        })
                        //_userService.createUser(user).done(function () {
                        //    $OrderAssign.modal('hide');
                        //    location.reload(true); //reload page to see new user!
                        //}).always(function () {
                        //    abp.ui.clearBusy(_$modal);
                        //});
                    });
                };

                $orderList.find('tr').find('span').on('click', function () {
                    console.log(this);
                    var orderId = $(this).attr('orderid');
                    selectOrderId = orderId;
                    console.log(orderId);
                    abp.ajax({
                        url: abp.appPath + 'PCOrder/GetAllSSUser',
                        type: 'GET',
                        data: {
                        },
                        success: function (data) {
                            var user = data;
                            if (user) {
                                var html = [];
                                for (var index = 0; index <= user.length - 1; index++) {
                                    var html1 = '<tr><td>' + user[index].UserName + '</td><td>' + user[index].PhoneNo + '</td><td>' + user[index].Address + '</td><td><input type="button" value="选择" class="btn btn-primary blue userSelect" userId="' + user[index].Id + '" openId="' + user[index].OpenId + '"></td></tr>';
                                    html.push(html1);
                                }

                                $Assign.html(html.join(''));
                                bind();
                            }
                        }
                    })
                });
            }
        });

        $datetimepicker.val(d).datetimepicker({
            language: 'zh-CN',
            format: 'yyyy-MM-dd',
            todayBtn: 1,
            autoclose: true,
            showMeridian: false,
            minView: 1,
            viewSelect: 'month'

        });

        $enddatetimepicker.val(d).datetimepicker({
            language: 'zh-CN',
            format: 'yyyy-MM-dd',
            todayBtn: 1,
            autoclose: true,
            showMeridian: false,
            minView: 1,
            viewSelect: 'month'

        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset/10,  //页码
            departmentname: "",
            status: $("#Status").val(),
            orderTime: $("#datetimepicker").val(),
            endTime:$enddatetimepicker.val(),
            OrderType: $("#OrderType").val()
        };
        return temp;
    };
    return oTableInit;
};


    $(function () {


        $('<audio id="chatAudio"><source src="../mp3/shoushou.mp3" type="audio/mpeg"><source src="mp3/notify.ogg" type="audio/ogg"><source src="mp3/notify.mp3" type="audio/mpeg"><source src="mp3/notify.wav" type="audio/wav"></audio>').appendTo('body');

      //  _$form.validate();

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            abp.ajax({
                url: abp.appPath + 'PCOrder/OrderAssign',
                type: 'GET',
                data: {
                    id: selectOrderId
                },
                success: function (data) {
                    var orderItem = data.Result.OrderItems, order = data.Result.Order;
                    if (orderItem) {
                        var html = [];
                        for (var index = 0; index <= orderItem.length - 1; index++) {
                            var html1 = '<tr><td>' + orderItem[index].ProductName + '</td><td>' + orderItem[index].ProductNum + '</td></tr>';
                            html.push(html1);
                        }

                        $detail.html(html.join(''));
                    }
                }
            })
            //_userService.createUser(user).done(function () {
            //    $OrderAssign.modal('hide');
            //    location.reload(true); //reload page to see new user!
            //}).always(function () {
            //    abp.ui.clearBusy(_$modal);
            //});
        });

        
       

        var ButtonInit = function () {
            var oInit = new Object();
            var postdata = {};

            oInit.Init = function () {
                $("#btn-query").on('click', function () {
                    $tableList.bootstrapTable('refresh');
                });

               
                //初始化页面上面的按钮事件
            };

            return oInit;
        };

      

       

        //1.初始化Table
        var oTable = new TableInit();
        oTable.Init();

        //2.初始化Button的点击事件
        var oButtonInit = new ButtonInit();
        oButtonInit.Init();

        setInterval(function () {
            var isClick = $isRefresh[0].checked;
            if (isClick) {
                $tableList.bootstrapTable('refresh');
            }
        }, 30000);
    });





