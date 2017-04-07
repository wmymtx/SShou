;
+(function (w, j,u) {

    var queryConfig = { url: { registerUrl: '/SS_WeiUser/Register' } };

    function checkName(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function checkPhone(val) {
        var re = /^1\d{10}$/
        if (re.test(val)) {
            return true;
        } else {
            return false;
        }
    }
    function checkWeChat(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function checkAddress(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function removeAllSpace(str) {
        return str.replace(/\s+/g, "");
    }
    function isCardNo(card) {
        // 身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X  
        var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
        if (reg.test(card) === false) {
            return false;
        }
        else {
            return true;
        }
    }
   

    var pageDom = {
        UserName: j("#name"),
        PhoneNo: j("#phone"),
        IdCard: j("#card"),
        AddressStart: j("#start"),
        AddressEnd: j("#address"),
        AllCheckbox: j("[type=checkbox]"),
        WorkingTime: j("#workingTime"),
        Submit: j("#submit")
    };

    var changeValue = [];

    var inOp = {
        Post: function (params) {
            var postParam = params || { url: '', type: 'post' };
            j.ajax({
                type: 'post', url: postParam.url || '', contentType: postParam.contentType || "application/json; charset=utf-8",
                data:JSON.stringify(postParam.data) || {}, dataType: postParam.dataType || "json",
                beforeSend: postParam.beforeSend || function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: postParam.success || function (data) {
                    $.toptip(data.msg, 'success');
                    w.reload();
                },
                error: postParam.error || function (msg) {
                    alert(msg);
                }
            });
        },
        Save: function () {

            var name = removeAllSpace($("#name").val());
            var time = $("#time").val();
           var workTime= $("#time").find("option:selected").text();
            var phone = $("#phone").val();
            var weChat = $("#weixin").val();
            var cardNo = $("#cardNo").val();
            var address = removeAllSpace($("#address").val());
            var street = removeAllSpace($("#street").val());
            var category = [],categoryName=[];
            $('input[name="category"]:checked').each(function () {
                category.push($(this).val());
                categoryName.push($(this).attr('valueName'));
            });
            if (name == "") {
                $.toptip('姓名不能为空！', 'error');
                return;
            } else if (checkPhone(phone) == false) {
                $.toptip('手机号格式错误！', 'error');
                return;
            } else if (checkWeChat(weChat) == false) {
                $.toptip('微信号格式错误！', 'error');
                return;
            } else if (isCardNo(cardNo) == false) {
                $.toptip('身份证格式错误！', 'error');
                return;
            } else if (address == "") {
                $.toptip('地址不能为空！', 'error');
                return;
            } else if (street == "") {
                $.toptip('街道不能为空！', 'error');
                return;
            } else if (category.length == 0) {
                $.toptip('请选择回收品类！', 'error');
                return;
            }
            console.log(category.toString());

            var param = {};
            param.UserName = name;
            param.PhoneNo = phone;
            param.Province = changeValue && changeValue[0];
            param.City = changeValue && changeValue[1];
            param.County = changeValue && changeValue[2];
            param.Weixin = weChat;
            param.FirstAddress = address;
            param.Address = street;
            param.WorkingTime = workTime;
            param.OpenId = openId;
            param.ID_Card = cardNo;
           

           
            param.RecyclingCategoryId = category.join('|');
            param.RecyclingCategoryName = categoryName.join('、');
          
            var postParam = {
                data: param, url: queryConfig.url.registerUrl, success: function (data) {
                    //$.toptip(data.Msg, 'success');
                    $.alert(data.Msg, "信息提示", function () {
                        //点击确认后的回调函数
                        w.location = w.location;
                    });
                   
                }, error: function () {
                    $.toptip("注册失败", 'success');
                }
            }

            inOp.Post(postParam);
        }
        ,
        init: function () {
            $("#address").cityPicker({
                title: "选择出发地",
                onChange: function (picker, values, displayValues) {
                    console.log(values, displayValues);
                    changeValue = values;
                }
            });

            pageDom.Submit.on('click', function () {
                inOp.Save();
            });
        }
    }

    u.init =inOp.init;

})(window, jQuery, window.ssUser || (window.ssUser = {}));