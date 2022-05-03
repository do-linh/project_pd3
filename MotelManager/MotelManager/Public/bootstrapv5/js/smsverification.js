var sendOTP = function () {
    var phone = document.getElementById("phone-input").value;
    var rePhone = '+84' + phone.substr(1, 9);
    $.ajax({
        url: "/Sms/sendOTP",
        type: "POST",
        data: { phone: rePhone },
        success: function (res) {

        }
    });
}
var formVerify = $('#form-verify')
var verifyOTP = function (username) {
    var phone = document.getElementById("phone-input").value;

    var rePhone = '+84' + phone.substr(1, 9);
    var OTPCode = document.getElementById("OTPCode").value;
    //var btnSubmit = $('#btnSubmit')
    //var btnBack = $('#btn-back')
    var user = username;
    console.log(user);
    $.ajax({
        url: "/Sms/verifyOTP",
        type: "POST",
        data: { phone: rePhone, OTP: OTPCode },
        success: function (res) {
            if (res == "approved") {
                swal("Xác thực thành công!", "Quay lại ", "success")
                    .then(res => {
                        $.ajax({
                            url: "/Sms/Verification",
                            type: "POST",
                            data: { phone: rePhone},
                            success: function () {
                                window.location.href = "/user/"+user
                            }
                        });
                    })
            } else {
                /*document.getElementById("verifyOTP").innerHTML = "Xác thực không thành công!";*/
                swal("Xác thực không thành công!", "", "error");
                /*document.getElementById('btnSubmit').disabled = true;*/
            }
        }
    });
}