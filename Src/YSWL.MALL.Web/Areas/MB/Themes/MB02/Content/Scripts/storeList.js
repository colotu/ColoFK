$(function () {
  
    //排序方式切换
    $('.modList').on('click', function () {
        if ($('#filter span').hasClass('icon_up')) {
            //关闭筛选
            closeFilter();
        }
        //点击自己保持不变
        if ($(this).hasClass('sort_a')) {
            return;
        }
        $('.modList').removeClass('sort_a');
        $(this).addClass('sort_a');
        $("#bgloading,#bg").css({ height: $(window).height(), display: 'block' });
        $('#mainList').load(getUrl(), function () {
            $("#bgloading,#bg").hide();
            $('#mainList').show();
        });
    });

    //显示筛选内容
    $('#filter').on('click', function (e) {
            var e = window.event || event;
            if (e.stopPropagation) {
                e.stopPropagation();
            } else {
                e.cancelBubble = true;
            }    
            showFilter();
            pullUp.Load = false;
            return;
    });


    //关闭筛选
    $(document).on('click', '#filter-back,#f_black_overlay', function () {
        closeFilter();
    });

    //分类页面返回按钮
    //$(document).on('click', '#pop2 .icon_goback', function () {
    //    $("#pop1 .header_title").show();
    //    $("#pop2").hide();
    //});

    //选中
    $(document).on('click', '.AreaIdValues', function () {
        var areaid=$(this).attr("AreaId");
        $("#hfAreaId").val(areaid);
        $("#arealist").find("span.tag_a").removeClass("tag_a");
        $(this).find("span").addClass("tag_a");
        closeFilter();
        $('#mainList').load(getUrl(), function () {
            $('#loading').hide();
        });
        $('#suppAreaList').load($YSWL.BasePath + "Partial/SuppAreasList", { AreaId: areaid, viewName: "_SuppAreasList"});
        $('#areaPathList').load($YSWL.BasePath + "Partial/SuppAreaPathList", { AreaId: areaid, viewName: "_SuppAreaPathList" });
    });

    $(document).on('click', '.navigation', function () {
        var areaid = $(this).attr("AreaId");
        $("#hfAreaId").val(areaid);
        closeFilter();
        $('#mainList').load(getUrl(), function () {
            $('#loading').hide();
        });
        $('#suppAreaList').load($YSWL.BasePath + "Partial/SuppAreasList", { AreaId: areaid, viewName: "_SuppAreasList" });
        $('#areaPathList').load($YSWL.BasePath + "Partial/SuppAreaPathList", { AreaId: areaid, viewName: "_SuppAreaPathList" });
    });

  
});

var getUrl = function () {
    var url = $YSWL.BasePath + "store/sl/{0}/{1}?{3}";
    return url.format($("#hfAreaId").val(), $('.modList.sort_a').attr('mod'), "ajaxVName=_StoreList");
}

//关闭筛选
function closeFilter() {
    $("#pop1,#pop2").animate({ right: "-90%" }, function () {
        $("#f_black_overlay,#pop1").hide();
    });
    $("body,html").css({ "overflow": "auto", "height": "auto" });
    //$("body").removeClass('overflow-h');
    pullUp.Load = true;
}
 
function showFilter() {
    $("#f_black_overlay,#pop1").show();
    $("#pop1").animate({ right: "0" });
    $("body,html").css({ "overflow": "hidden", "height": $(window).height() });
    $("#pop1 .header_title").show();
}