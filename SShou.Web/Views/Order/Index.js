; (function (win, $, a) {
    var sourceConfig = {
        urls: {
            getAllDataUrl: '/UserAddress/getAll',
            getInfoByIdUrl: '/UserAddress/getDetailById',
            editInfoUrl: '/UserAddress/EditAddress',
            setDefaultUrl: '/UserAddress/SetDefault',
            addNewAddress: '/UserAddress/AddNewAddress',
            removeAddress: '/UserAddress/RemoveAddress'
        }
    };

    var ajaxTool = {
        Post: function (params) {
            var postParam = params || { url: '', type: 'post' };
            $.ajax({
                type: 'post', url: postParam.url || '', contentType: postParam.contentType || "application/json; charset=utf-8",
                data: postParam.data || {}, dataType: postParam.dataType || "json",
                beforeSend: postParam.beforeSend || function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: postParam.success || function (data) {

                },
                error: postParam.error || function (msg) {
                    alert(msg);
                }
            });
        },
        Get: function (params) {
            var postParam = params || { url: '', type: 'post' };
            $.ajax({
                type: 'get', url: postParam.url || '', contentType: postParam.contentType || "application/json; charset=utf-8",
                data: postParam.data || {}, dataType: postParam.dataType || "json",
                beforeSend: postParam.beforeSend || function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: postParam.success || function (data) {

                },
                error: postParam.error || function (msg) {
                    alert(msg);
                }
            });
        }
    };

    var addressService = {
        IsEdit: 0,
        parentsDom: null,
        getAll: function (fn) {
            var params = {
                url: sourceConfig.urls.getAllDataUrl, success: function (data) {
                    fn && fn(data);
                }
            };
            ajaxTool.Get(params);
        }, getDetailById(id, fn) {
            var params = {
                data: { "addrId": id },
                url: sourceConfig.urls.getInfoByIdUrl, success: function (data) {
                    fn && fn(data);
                }
            };
            ajaxTool.Get(params);
        }

    };
    var jqDom = {
        $tableList: $("#tableList")
    };
    var addressController = {
        getAll: function () {
            addressService.getAll(function (data) {
                if (data) {
                    var htmlArr = [];
                    var d = data.Result;
                    for (var index = 0; index <= d.length - 1; index++) {
                        var t = '<div class="weui_media_box weui_media_text"  addrId="' + d[index].Id + '">'
                        + '<h4 class="weui_media_title">' + d[index].ContactName + '  ' + d[index].PhoneNo + '</h4>'
                        + '<p class="weui_media_desc">' + d[index].Address + '</p> <ul class="weui_media_info">'
                        + ' </ul></div>';
                        htmlArr.push(t);
                        console.log(t);
                    }
                    jqDom.$tableList.empty().append(htmlArr.join(''));
                    addressController.InitEvent();
                }
            });
        }
        , getDetailById: function (id) {
            addressService.getDetailById(id, function (data) {
                if (data) {
                    $("#RecUserName").val(data.Result.ContactName);
                    $("#RecPhone").val(data.Result.PhoneNo);
                    $("#address").val(data.Result.Address);
                    $.closePopup();
                }
            });
        }, InitEvent: function () {
            jqDom.$tableList.children().each(function () {
                var liList = $(this).find('li');
                $(this).on('click', function () {
                    var id = $(this).attr("addrId");
                    if (id > 0) {
                        addressController.getDetailById(id);
                    }
                });
                
            });
        }
    }
    a.Init = addressController.getAll;
})(window, jQuery, window.address || (window.address = {}));


(function () { // 闭包
    function load_script(xyUrl, callback) {
        var head = document.getElementsByTagName('head')[0];
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.src = xyUrl;
        // 借鉴了jQuery的script跨域方法
        script.onload = script.onreadystatechange = function () {
            if ((!this.readyState || this.readyState === "loaded" || this.readyState === "complete")) {
                callback && callback();
                // Handle memory leak in IE
                script.onload = script.onreadystatechange = null;
                if (head && script.parentNode) {
                    head.removeChild(script);
                }
            }
        };
        // Use insertBefore instead of appendChild to circumvent an IE6 bug.
        head.insertBefore(script, head.firstChild);
    }
    function translate(point, type, callback) {
        var callbackName = 'cbk_' + Math.round(Math.random() * 10000); // 随机函数名
        var xyUrl = "http://api.map.baidu.com/ag/coord/convert?from=" + type
                + "&to=4&x=" + point.lng + "&y=" + point.lat
                + "&callback=BMap.Convertor." + callbackName;
        // 动态创建script标签
        load_script(xyUrl);
        BMap.Convertor[callbackName] = function (xyResult) {
            delete BMap.Convertor[callbackName]; // 调用完需要删除改函数
            var point = new BMap.Point(xyResult.x, xyResult.y);
            callback && callback(point);
        }
    }

    window.BMap = window.BMap || {};
    BMap.Convertor = {};
    BMap.Convertor.translate = translate;
})();