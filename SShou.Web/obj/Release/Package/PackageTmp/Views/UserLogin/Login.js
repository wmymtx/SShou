(function () {

    $(function () {
        $('#LoginButton').click(function (e) {
            e.preventDefault();
            abp.ui.setBusy(
                $('#LoginArea'),
                abp.ajax({
                    url: abp.appPath + 'UserLogin/Login',
                    type: 'POST',
                    data: JSON.stringify({
                        UserName: $('#EmailAddressInput').val(),
                        PassWord: $('#PasswordInput').val(),
                    }),
                    success: function (data) {
                        if (data.Code == 200) {
                            window.location.href = "/Home/Index";
                        }
                        else {
                            alert(data.Msg);
                        }
                    }
                })
            );
        });

        $('a.social-login-link').click(function () {
            var $a = $(this);
            var $form = $a.closest('form');
            $form.find('input[name=provider]').val($a.attr('data-provider'));
            $form.submit();
        });

        $('#ReturnUrlHash').val(location.hash);

        $('#LoginForm input:first-child').focus();
    });

})();