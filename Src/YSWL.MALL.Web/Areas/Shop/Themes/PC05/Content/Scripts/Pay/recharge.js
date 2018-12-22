var RechargeRatio;
var RechargeRatioStates = false;
function cleanMes() {
    $(".msg-error").html("");
}
function checkMoney() {
    var account = $("#txtMoney").val();
    if (account == "") {
        $('#lblMoney').text("0.00");
        return;
    }

    if (parseInt(account) > 1000000) {
        $(".msg-error").html("只能填写大于0，小于1000000的金额");
        return;
    }
    if (RechargeRatioStates) {
        var payMoney = parseFloat(account) / RechargeRatio;
        $('#lblMoney').text(payMoney.toFixed(2));
    }
}

function DoChonge() {
    checkMoney();
    var money = $("#txtMoney").val();
    var mes = $(".msg-error").html();
    if (money == '') {
        ShowFailTip("请填写充值金额！");
        return false;
    }
    if (mes != "") {
        return false;
    }
    var paymentvalue = $("input[type='radio']:checked").val();
    if (!paymentvalue) {
        ShowFailTip("请选择支付方式！");
        return false;
    }
    submitreturn(money, paymentvalue);
}

function submitreturn(money, paymentvalue) {

    $.ajax({
        type: "post",
        url: $YSWL.BasePath + "UserCenter/AjaxRecharge",
        dataType: "text",
        timeout: 6000,
        async: false,
        data: {
            rechargmoney: money, payid: paymentvalue
        },
        success: function (result) {
            if (result == "No") {
                ShowFailTip("服务器繁忙请稍候再试！");
            }
            else {
                window.location.href = $YSWL.BasePath + "UserCenter/RechargeConfirm?id=" + result;
            }
        },
        Error: function () {
            ShowFailTip("服务器繁忙请稍候再试！");
        }
    });
}


$(function () {
    RechargeRatio = $('#hidRechargeRatio').val();
    if ($.trim(RechargeRatio) != '' && RechargeRatio != '1' && RechargeRatio != '1.0') {
        $('#divrechargeMoney').show();
        RechargeRatioStates = true;
    }
    $('#txtMoney').OnlyFloat();



    $("#txtMoney").keyup(function () {
        checkMoney();
    });
});