var $tableList = $("#orderList"), $datetimepicker = $('#datetimepicker'), $isRefresh = $("#isRefresh");

var orderStatusDic = {
    0: "待指派", 1: "已指派", 2: "已完成", "-1": "已撤销", 3: "已评分"
};

var $OrderAssign = $('#OrderAssign'), $OrderDetail = $("#OrderDetail"), $detail = $("#detail"), $orderList = $("#orderList"), $Assign = $("#Assign");
var _$form = $OrderAssign.find('form');
var selectOrderId;

var o = {
    name: $("#name"),
    time: $("#time"),
    phone: $("#phone"),
    wechat: $("#wechat"),
    card: $("#card"),
    area: $("#area"),
    prod: $("#prod")
}

var d_o = {
    name: $("#d_name"),
    time: $("#d_time"),
    phone: $("#d_phone"),
    wechat: $("#d_wechat"),
    card: $("#d_card"),
    area: $("#d_area"),
    prod: $("#d_prod")
}

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {

        function bind(id, status, userId) {
            $(id).unbind('click').click(function (e) {
                e.preventDefault();


                abp.ui.setBusy($OrderAssign);
                abp.ajax({
                    url: abp.appPath + 'SSUser/EditStatus',
                    type: 'GET',
                    data: {
                        userId: userId, status: status
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

        $tableList.bootstrapTable({
            url: '/SSUser/GetOrderList',         //请求后台的URL（*）
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
                field: 'UserName',
                title: '姓名'

            }, {
                field: 'PhoneNo',
                title: '号码'
            }, {
                field: 'Address',
                title: '地址'
            }, {
                field: 'WorkingTime',
                title: '从业时长'
            }, {
                field: 'ID_Card',
                title: '身份号码'
            }, {
                field: 'Remark',
                title: '备注'
            }, {
                align: 'center',
                field: '#',
                title: '查看详情', formatter: function (value, row, index) {
                    return '<p data-toggle="modal" orderId="' + row.Id + '" data-target="#OrderDetail" class="btn btn-info">查看详情</p>';
                }
            }, {
                align: 'center',
                field: '##',
                title: '操作', formatter: function (value, row, index) {
                    if (row.Status == 0)
                        return '<span data-toggle="modal" orderId="' + row.Id + '" data-target="#OrderAssign" class="btn btn-primary">审核</span>';
                    else
                        return '';
                }
            }], onLoadSuccess: function () {
                $OrderAssign.on('shown.bs.modal', function () {
                    $OrderAssign.find('input:not([type=hidden]):first').focus();
                });
                $OrderDetail.on('shown.bs.modal', function () {

                    $OrderDetail.find('input:not([type=hidden]):first').focus();

                });

                $orderList.find('tr').find('span').on('click', function () {
                    console.log(this);
                    var orderId = $(this).attr('orderid');
                    console.log(orderId);
                    abp.ajax({
                        url: abp.appPath + 'SSUser/GetDetail',
                        type: 'GET',
                        data: {
                            userId: orderId
                        },
                        success: function (data) {

                            if (data) {
                                o.name.html(data.UserName);
                                o.phone.html(data.PhoneNo);
                                o.wechat.html(data.Weixin);
                                o.area.html(data.FirstAddress + data.Address);
                                o.time.html(data.WorkingTime);
                                o.prod.html(data.RecyclingCategoryName);
                                o.card.html(data.ID_Card);
                                bind("#unPass", -1, data.Id);
                                bind("#pass", 1, data.Id);
                            }
                        }
                    })
                });



                $orderList.find('tr').find('p').on('click', function () {
                    console.log(this);
                    var orderId = $(this).attr('orderid');
                    selectOrderId = orderId;
                    console.log(orderId);
                    abp.ajax({
                        url: abp.appPath + 'SSUser/GetDetail',
                        type: 'GET',
                        data: {
                            userId: orderId
                        },
                        success: function (data) {

                            if (data) {
                                d_o.name.html(data.UserName);
                                d_o.phone.html(data.PhoneNo);
                                d_o.wechat.html(data.Weixin);
                                d_o.area.html(data.FirstAddress + data.Address);
                                d_o.time.html(data.WorkingTime);
                                d_o.prod.html(data.RecyclingCategoryName);
                                d_o.card.html(data.ID_Card);

                            }
                        }
                    })
                });
            }
        });


    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            departmentname: "",
            status: $("#Status").val(),
            orderTime: $("#datetimepicker").val()
        };
        return temp;
    };
    return oTableInit;
};


$(function () {




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

            setTimeout(function () {
                var isClick = $isRefresh.attr("checked");
                if (isClick) {
                    $tableList.bootstrapTable('refresh');
                }
            }, 30000);
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
});





