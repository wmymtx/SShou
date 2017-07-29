; (function (win, $) {
    'use strict';
    var $list = $("#list"), $btnOk = $("#btnOk"), $btnCancel = $("#btnCancel"), $about = $("#about"), score, orderId, orderStatus = 0;
    var SearchParams = { PageIndex: 0, PageSize: 5 };
    var $content = $("#content");
    var orderStatusDic = {
        0: "待指派", 1: "已指派", 2: "已完成", "-1": "已撤销", 3: "已评分"
    };
    var historyIndex = {
        _creteHtml: function (item) {
            var html = '<div id="' + item.Id + '" orderStatus="' + item.Status + '" class="weui_media_box weui_media_text">'
            + ' <h4 class="weui_media_title">' + item.RecTime + '</h4>'
            + '<p class="weui_media_desc">' + item.ItemAll + '</p>'
            + '<ul class="weui_media_info">'
            + ' <li class="weui_media_info_meta">飞翔的企鹅</li>'
            + ' <li class="weui_media_info_meta">' + orderStatusDic[item.Status] + '</li></ul></div>';
            return html;
        },
        BindTapEvent: function () {
            $("#list div").each(function () {
                $(this).click(function () {
                    var id = $(this).attr("id");
                    orderStatus = $(this).attr("orderStatus");
                    orderId = id;
                    if (orderStatus === 2) {
                        $content.val('');
                        $about.popup();
                    } else if (orderStatus === 3) {
                        $.toast("不能重复评分", "forbidden");
                    }
                    else {
                        $.toast("订单未完成，暂时无法评分", "forbidden");
                    }
                });
            });
            return this;
        },
        _getOrderInfo: function () {
            console.log(historyIndex);
            SearchParams.PageIndex++;
            var self = this;
            $.ajax({
                type: 'GET', url: '/Order/GetHistory', contentType: "application/json; charset=utf-8",
                data: SearchParams, dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: function (data) {

                    if (data) {
                        var htmlArr = [];
                        for (var index = 0; index <= data.length - 1; index++) {

                            htmlArr.push(historyIndex._creteHtml(data[index]));
                        }
                        $list.append(htmlArr.join(''));
                        historyIndex.BindTapEvent();
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }, OrderComment: function (orderId) {
            var content = $content.val();
            if (content.length <= 0)
            {
                $.toast("请输入评价", "forbidden");
                return;
            }
            if (historyPage.score <= 0) {
                $.toast("请选择评分分数", "forbidden");
                return;
            }
            $.ajax({
                type: 'Post', url: '/Order/OrderComment', contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ F_OrderId: orderId, Score: historyPage.score, Comment: content }), dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: function (data) {

                    if (data) {
                        $.toast("评分成功", 3000);
                        $("#" + orderId).attr("orderStatus", 3).find('li').eq(1).html('已评分');
                        $.closePopup();
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }
        , InitPage: function () {
            $(document.body).pullToRefresh();
            $(document.body).on("pull-to-refresh", function () {
                historyIndex._getOrderInfo();
                console.log('a');
                $(document.body).pullToRefreshDone();
            });
            //$(document.body).infinite(50).on("infinite", function () {
            //    historyIndex._getOrderInfo();
            //});
            $btnOk.on('click', function () {
                historyIndex.OrderComment(orderId);
            });
            $btnCancel.on('click', function () {
                // $about.popup('close');
                $.closePopup();
            });
        }, BindOkFunc: function (id) {
            $.ajax({
                url: '', type: 'POST', contentType: 'application/json;charset=utf-8',
                data: { id: id }, dataType: 'json', beforeSend: function (xhr) {
                    console.log(xhr);
                }, success: function (data) {
                    if (data) {
                        if (data.Code === 200) {
                            alert(data.msg);
                            $.closePopup();
                        }
                        else {
                            alert(data.msg);
                        }
                    }
                }
            })
        }
    };
    win.historyPage = { historyIndex: historyIndex._getOrderInfo, InitPage: historyIndex.InitPage, score: score };
})(window, jQuery);