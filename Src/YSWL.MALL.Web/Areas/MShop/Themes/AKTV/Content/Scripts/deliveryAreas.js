//加载配送地区
function loadDeliveryAreas() {
    if ($.cookie('deliveryareas_regionId') == null) {
        //初始化配送地区
        $.ajax({
            type: "POST",
            dataType: "text",
            url: $YSWL.BasePath + "Partial/InitializeRegionId",
            async: true,
            success: function (data) {
//                if (data == "True") {
//                    $('#l_regionfullname').text($.cookie('deliveryareas_regionname')); //初始化成功    
//                }
            }
        });
    }  
    if ($.cookie('deliveryareas_regionname') == null || $.cookie('deliveryareas_regionname') == '') {
        $('#l_regionfullname').text("设置");
    } else {
        $('#l_regionfullname').text($.cookie('deliveryareas_regionname'));
    }


    //选择配送地区

    $('#p_tan_ceng').die("click").live("click",function () {  
        if ($('#divDeliveryAreas #hfSelectedNode').length <= 0) {
            $('#divDeliveryAreas').append("<script src=\"/Scripts/jquery/jquery.guid.js\" type=\"text/javascript\"><\/script><input type=\"hidden\" id=\"hfSelectedNode\"/> <script type=\"text/javascript\" >$('#hfSelectedNode').val($.cookie('deliveryareas_regionId'));<\/script><script src=\"/Scripts/jquery/maticsoft.selectregion.delivery.js\" handle=\"/RegionHandle.aspx\" isnull=\"true\" type=\"text/javascript\"><\/script> ");
        }
       //$('[item="ceng_content_selector"]').show("slow");

        $('[item="ceng_content_selector"]').animate({
            right: "0",
        }, 1000);

    });

    //关闭层
    $('#c_close_a').die("click").live("click",function () { 
        $('[item="ceng_content_selector"]').animate({
        right: "-100%",
    }, 1000);
    });
    

}

//设置配送地区
function setDeliveryAreas(regoinId) {
    //记录regionId
    $.cookie('deliveryareas_regionId', regoinId, { expires: 1, path: '/' });
    //地区全名称
    var regionFullName = "";
    $("#divDeliveryAreas select").each(function () {
        regionFullName += $(this).find("option:selected").text();
    });
    //去除重复名
    if (regionFullName.indexOf('北京北京') != -1) {
        regionFullName = regionFullName.replace('北京北京', '北京');
    } else if (regionFullName.indexOf('上海上海') != -1) {
        regionFullName = regionFullName.replace('上海上海', '上海');
    } else if (regionFullName.indexOf('重庆重庆') != -1) {
        regionFullName = regionFullName.replace('重庆重庆', '重庆');
    } else if (regionFullName.indexOf('天津天津') != -1) {
        regionFullName = regionFullName.replace('天津天津', '天津');
    }
    $.cookie('deliveryareas_regionname', regionFullName, { expires: 1, path: '/' });
    $('#l_regionfullname').text(regionFullName);
    //$('[item="ceng_content_selector"]').hide("slow");
    $('[item="ceng_content_selector"]').animate({
        right: "-100%",
    }, 1000);
}

