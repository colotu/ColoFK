function loadmap(mapid, inputId) {
    var value = $("#"+inputId).val();
 if (value != "")
     return;
    var map = new BMap.Map(mapid);
    map.centerAndZoom("北京", 12);                   // 初始化地图,设置城市和地图级别。
    var ac = new BMap.Autocomplete(    //建立一个自动完成的对象
    {
    "input": $('#' + inputId).get(0),
    "location": map,
    "onSearchComplete": function (autocompleteResult) {
        $('.tangram-suggestion-main').css({ 'z-index': '2009' });
    }
});
var myValue;
ac.addEventListener("onconfirm", function (e) {
    //鼠标点击下拉列表后的事件
    var _value = e.item.value;
    myValue = _value.province + _value.city + _value.district + _value.street + _value.business;
    setPlace();
});
function setPlace() {
    function myFun() {
        var mapcoder = new BMap.Geocoder();
        var pp = local.getResults().getPoi(0).point;    //获取第一个智能搜索的结果
        $('#' + inputId+"_Lng").val(pp.lng);
        $('#' + inputId + "_Lat").val(pp.lat);
        mapcoder.getLocation(pp,
          function (geocoderResult) {
              var province = geocoderResult.addressComponents.province;
              $('#' + inputId).attr("province", province);

          });
          
    }
    var local = new BMap.LocalSearch(map, { //智能搜索
        onSearchComplete: myFun
    });
    local.search(myValue);
}
}