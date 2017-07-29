var orderHelper = {};
; (function (window, $, out) {

    var SearchParams = { PageIndex: 0, PageSize: 5 };
    var $orders = $("#orders"), $loadMore = $("#loadMore"), $loading = $("#loading"), $loadings = $("#loadings"), $noMoreData = $("#noMoreData"), $previewPage = $("#previewPage"), $orderList = $("#orderList"),
        $btn_prev = $("#btn_prev"), $btn_back = $("#btn_back"), $orderItems = $("#orderItems"),
        $preview_order_status = $("#preview_order_status"), $preview_ssperson = $("#preview_ssperson"), $preview_ssphone = $("#preview_ssphone"), $btnCancel = $("#btnCancel"), $person = $("#person"), $phone = $("#phone");
    var $btnSure = $("#btnSure"), $addr = $("#addr");
    var orderStatusDic = {
        0: "待指派", 1: "已指派", 2: "已完成", "-1": "已撤销", 3: "已评分"
    };

    var innerFunc = {
        HideLoadMore: function (data) {
            if (data && data.length > 0) {
                $loading.hide();
                $loadMore.show();
            } else {
                $loadings.hide();
                $noMoreData.show();
            }
        }
    };


    var order = {
        getOrderInit: function () {
            var self = this;
            console.log($orders);
            SearchParams.PageIndex++;
            $.ajax({
                type: 'GET', url: '/Order/GetOrderList', contentType: "application/json; charset=utf-8",
                data: SearchParams, dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                    $loading.show();
                    $loadMore.hide();
                },
                success: function (data) {
                    innerFunc.HideLoadMore(data);
                    if (data) {
                        var htmlArr = [];
                        for (var index = 0; index <= data.length - 1; index++) {
                            var html = ' <a class="weui-cell weui-cell_access js_item" data-id="preview" href="javascript:;" id="' + data[index].Id + '"><div class="weui-cell__bd"><p>' + data[index].OrderTime + '</p></div><div class="weui-cell__ft">' + orderStatusDic[data[index].Status] + '</div></a>';
                            htmlArr.push(html);
                        }
                        $("#orders").append(htmlArr.join(''));
                        console.log(htmlArr.join(''));
                        console.log($("#orders").html());
                        self.BindTapEvent();
                    }
                },
                error: function (msg) {
                   // alert(msg);
                }
            });
        },
        cancelOrder: function (id) {
            $.confirm('订单取消提示', "是否要取消该订单", function () {
            $.ajax({
                type: 'GET', url: '/Order/CancelOrder', contentType: "application/json; charset=utf-8",
                data: { id: id }, dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: function (data) {
                    //innerFunc.HideLoadMore(data);
                    var json = JSON.stringify(data);
					$.toast("撤销成功！");
                    $btnCancel.hide();
                },
                error: function (msg) {
                    //alert(msg);
                }
                });
            }, function () { });
        },
        canOrder: function (id) {
           
                $.ajax({
                    type: 'GET', url: '/Order/CanOrder', contentType: "application/json; charset=utf-8",
                    data: { id: id }, dataType: "json",
                    beforeSend: function (xhr) {
                        console.log(xhr);
                        console.log('发送前');
                    },
                    success: function (data) {
                        //innerFunc.HideLoadMore(data);
                        var json = JSON.stringify(data);
                        $.toast("操作成功！");
                        $btnCancel.hide();
                    },
                    error: function (msg) {
                        //alert(msg);
                    }
                });
          
        },
        _getDetailData: function (id) {
            $.ajax({
                type: 'GET', url: '/Order/GetOrderDetail', contentType: "application/json; charset=utf-8",
                data: { id: id }, dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: function (data) {
                    //innerFunc.HideLoadMore(data);
                    if (data.result.code == 200) {
                        var orderItem = data.result.result.orderItems, orderData = data.result.result.order;
                        if (orderItem) {
                            var html = [];
                            for (var index = 0; index <= orderItem.length - 1; index++) {
                                var html1 = '<div class="weui_cell"><div class="weui_cell_bd weui_cell_primary"><p>' + orderItem[index].productName + '</p></div><div class="weui_cell_ft">' + orderItem[index].productNum  + orderItem[index].unit + '</div></div></div>';
                                html.push(html1);
                            }
                            $orderItems.html(html.join(''));
                        }
                        if (orderData) {
                            if (orderData.status == 0) {
                                $btnCancel.show();
                                $btnCancel.on('click', function () {
                                    order.cancelOrder(orderData.id);
                                });
                            } else if (orderData.status == 1) {
                                $btnSure.show();
                                $btnSure.on('click', function () {
                                    order.canOrder(orderData.id);
                                });
                            }
                            else
                            {
                                $btnCancel.hide();
                                $btnSure.hide();
                            }
                            $person.html(orderData.recUserName);
                            $phone.html(orderData.recPhone);
                            $preview_order_status.html(orderStatusDic[orderData.status]);
                            $preview_ssperson.html(orderData.personName);
                            $preview_ssphone.html(orderData.phoneNo);
                            $addr.html(orderData.address);
                        }

                    }
                },
                error: function (msg) {
                    //alert(JSON.stringify(msg));
                }
            });
        }, getDetailData(orderId) {
            order._getDetailData(orderId);
        }
        ,
        getMoreOrderList: function () {

        },
        InitTapEvent: function () {
            $previewPage.hide();
            $loadMore.click(function () {
                order.getOrderInit();
            });
            $btn_prev.on('click', function () {
                $previewPage.hide();
                $orderList.show();
            })
            $btn_back.on('click', function () {
                location.href = '/UserProfile/Index';
            });
        },
        BindTapEvent: function () {
            var self = this;
            var oFunc = this._getDetailData;
            $('a[data-id="preview"]').each(function () {
                $(this).click(function () {
                    console.log($(this).attr('id'));
                    var id = $(this).data('id');
                    oFunc($(this).attr('id'));
                    $previewPage.show();
                    $orderList.hide();
                    // window.pageManager.go(id);
                })

            });

        }
    };
    out.ExecParam = order;
})(window, jQuery, orderHelper)

