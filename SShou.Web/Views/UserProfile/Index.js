; (function (w, $) {
    var $points = $("#points"), $pointSpan = $("#pointSpan"), $ponitScore = $("#ponitScore"), $alertUser = $("#alertUser"), $userAddress = $("#userAddress");
    var pointFlag = 1;
    var userPorfile = {
        SearchStatus: function () {
            var self = this;
            $.ajax({
                type: 'Post', url: '/UserProfile/SearchStatus', contentType: "application/json; charset=utf-8",
                data: {}, dataType: "json",
                beforeSend: function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: function (data) {

                    if (data) {
                        pointFlag = data.Code;
                        $pointSpan.html(data.Msg);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        },
        InitEvent: function () {
            var self = this;

            userPorfile.SearchStatus();
            $points.on('click', function () {
                userPorfile.signIn();
            });
            $alertUser.on('click', function () {
                window.location.href = '/UserProfile/AlterUserInfo';
            });

            $userAddress.on('click', function () {
                window.location.href = '/UserAddress/Index';
            });
        }, signIn: function () {
            if (pointFlag <= 0) {
                $.ajax({
                    type: 'Post', url: '/UserProfile/SignValidate', contentType: "application/json; charset=utf-8",
                    data: {}, dataType: "json",
                    beforeSend: function (xhr) {
                        console.log(xhr);
                        console.log('发送前');
                    },
                    success: function (data) {
                        if (data) {
                            pointFlag = data.Code;
                            $pointSpan.html(data.Msg);
                            var nowPoints = Number($ponitScore.html());
                            $ponitScore.html(Number(nowPoints) + Number(data.Result));
                            $.toast("+5</br>签到成功", 3000);
                        }
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });
            }
            else {
                //  $.toptip("今日已经签到", 3000, 'warning');
                $.toast("今日已经签到", "forbidden");
            }
        }

    };


    window.PointsSign = { PageInit: userPorfile.InitEvent };
})(window, jQuery);