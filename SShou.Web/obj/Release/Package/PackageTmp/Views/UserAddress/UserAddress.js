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
        },
        /*
        *设置默认地址
        */
        SetDefault: function (id, fn) {
            var params = {
                data: JSON.stringify({ "id": id }),
                url: sourceConfig.urls.setDefaultUrl, success: function (data) {
                    fn && fn(data);
                }, error: function (data) {
                    alert(JSON.stringify(data));
                }
            };
            ajaxTool.Post(params);
        },
        /*编辑地址*/
        EditInfo: function (formData, fn) {
            var params = {
                data: formData,
                url: sourceConfig.urls.editInfoUrl, success: function (data) {
                    fn && fn(data);
                }
            };
            ajaxTool.Post(params);
        }, AddNew: function (formData, fn) {
            var params = {
                data: formData,
                url: sourceConfig.urls.addNewAddress, success: function (data) {
                    fn && fn(data);
                }
            };
            ajaxTool.Post(params);
        }, RemoveAddress: function (id, fn) {
            var params = {
                data: JSON.stringify({ "id": id }),
                url: sourceConfig.urls.removeAddress, success: function (data) {
                    fn && fn(data);
                }
            };
            ajaxTool.Post(params);
        }

    };
    var jqDom = {
        $btnCancel: $("#btnCancel"), $btnAdd: $("#btnAdd"), $btnSave: $("#btnSave"), $txtName: $("#txtName"), $txtPhone: $("#txtPhone")
        , $txtAddress: $("#txtAddress"), $tableList: $("#tableList"), $content: $("#content")
    };
    var addressController = {
        getAll: function () {
            addressService.getAll(function (data) {
                if (data) {
                    var htmlArr = [];
                    var d = data.Result;
                    for (var index = 0; index <= d.length - 1; index++) {
                        var t = '<div class="weui_media_box weui_media_text">'
                        + '<h4 class="weui_media_title">' + d[index].ContactName + '  ' + d[index].PhoneNo + '</h4>'
                        + '<p class="weui_media_desc">' + d[index].Address + '</p> <ul class="weui_media_info">'
                        + '  <li class="weui_media_info_meta" addrId="' + (d[index].IsDefault == 0 ? d[index].Id + '">设为默认</li>' : '0">默认地址</li>"')
                        + ' <li class="weui_media_info_meta weui_media_info_meta_extra" addrId="' + d[index].Id + '">修改</li>'
                        + ' <li class="weui_media_info_meta weui_media_info_meta_extra" addrId="' + d[index].Id + '">删除</li> </ul></div>';
                        htmlArr.push(t);
                        console.log(t);
                    }
                    jqDom.$tableList.empty().append(htmlArr.join(''));
                    addressController.InitEvent();
                }
            });
        },
        EditAddress: function () {
            var name = jqDom.$txtName.val();
            var phone = jqDom.$txtPhone.val();
            var address = jqDom.$txtAddress.val();
            if (!checkName(name)) {
                $.toptip('姓名不能为空！', 'error');
            }
            else if (!checkPhone(phone)) {
                $.toptip('手机号码错误！', 'error');
            }
            else if (!checkAddress(address)) {
                $.toptip('地址不能为空！', 'error');
            }
            else {
                $.showLoading("正在保存...");
                var formData = { PhoneNo: phone, Address: address, ContactName: name };

                if (addressService.IsEdit) {
                    formData.Id = addressService.IsEdit;
                    formData = JSON.stringify(formData);
                    addressService.EditInfo(formData, function (data) {

                        addressService.IsEdit = 0;
                        $.hideLoading();
                        $.toast("操作成功");
                        $.closePopup();
                        jqDom.$btnAdd.show();
                        addressController.getAll();
                    });
                } else {
                    formData = JSON.stringify(formData);
                    addressService.AddNew(formData, function (data) {
                        $.hideLoading();
                        $.toast("操作成功");
                        $.closePopup();
                        jqDom.$btnAdd.show();
                        addressController.getAll();
                    });
                }
            }
        }
        , RemoveAddress: function (id) {
            addressService.RemoveAddress(id, function (data) {
                if (data.Code == 200) {
                    $.toast("操作成功");
                    addressService.parentsDom && addressService.parentsDom.remove();
                }
            });
        }
        , getDetailById: function (id) {
            addressService.getDetailById(id, function (data) {
                if (data) {
                    jqDom.$txtName.val(data.Result.ContactName);
                    jqDom.$txtPhone.val(data.Result.PhoneNo);
                    jqDom.$txtAddress.val(data.Result.Address);
                }
            });
        }, SetDefault: function (id) {
            addressService.SetDefault(id, function (rst) {
                if (rst.Code == 200) {
                    $.toast("操作成功");
                    addressController.getAll();
                }
                else {
                    $.toast(rst.Msg, "forbidden");
                }
            });
        }, Init: function () {
            addressController.getAll();
            jqDom.$btnAdd.on('click', function () {
                jqDom.$btnAdd.hide();
                jqDom.$content.popup();
            });
            jqDom.$btnCancel.on('click', function () {
                $.closePopup();
                jqDom.$btnAdd.show();
            });
            jqDom.$btnSave.on('click', function () {
                addressController.EditAddress();
            })

        }, InitEvent: function () {
            jqDom.$tableList.children().each(function () {
                var liList = $(this).find('li');
                $(liList[0]).on('click', function () {
                    var id = $(this).attr("addrId");
                    if (id > 0) {
                        addressService.parentsDom = $(this).parents('.weui_media_box');
                        addressController.SetDefault(id);
                    } else {
                        $.toast("该项当前已为默认地址", "forbidden");
                    }
                });
                $(liList[1]).on('click', function () {
                    var id = $(this).attr("addrId");
                    addressService.IsEdit = id;
                    addressController.getDetailById(id);
                    jqDom.$btnAdd.hide();
                    jqDom.$content.popup();
                });
                $(liList[2]).on('click', function () {
                    var id = $(this).attr("addrId");
                    addressService.parentsDom = $(this).parents('.weui_media_box');
                    $.confirm("是否确认要删除该地址信息", "删除数据", function () {
                        addressController.RemoveAddress(id);
                    }, function () { });

                });
            });
        }
    }
    a.Init = addressController.Init;
})(window, jQuery, window.address || (window.address = {}));