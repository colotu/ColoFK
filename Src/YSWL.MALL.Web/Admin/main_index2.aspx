<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_index2.aspx.cs" Inherits="YSWL.MALL.Web.Admin.main_index2" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>云商框架</title>
    <script src="/admin/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/admin/css/admin.css" rel="stylesheet" type="text/css" />
    <link href="/admin/js/easyui/easyui.css" rel="stylesheet" type="text/css" />
    <script src="/admin/js/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="/admin/css/dinghuo_xc.css" rel="stylesheet" type="text/css" />
    <link href="/admin/css/reset_dinghuo_xc.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/Highcharts/highcharts.js" type="text/javascript"></script>
    <script src="/Scripts/jquery/maticsoft.jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function addTab(title, url) {
            if ($('#tabs').tabs('exists', title)) {
                $('#tabs').tabs('select', title); //选中并刷新
                var currTab = $('#tabs').tabs('getSelected');
                var url = $(currTab.panel('options').content).attr('src');
                if (url != undefined && currTab.panel('options').title != '我的桌面') {
                    $('#tabs').tabs('update', {
                        tab: currTab,
                        options: {
                            content: createFrame(url)
                        }
                    });
                }
            } else {
                var index = $('#tabs').find(".tabs").find("li").length;
                if (index == 20) {
                    alert("开启的菜单太多，请先关闭部分菜单！");
                    return;
                }
                var content = createFrame(url);
                $('#tabs').tabs('add', {
                    title: title,
                    content: content,
                    closable: true
                });
            }
            tabClose();
        }
        function createFrame(url) {
            var s = '<iframe scrolling="auto" frameborder="0"  border="0px" src="' + url + '" style="width:100%;height:99%;"></iframe>';
            return s;
        }

        function tabClose() {
            /*双击关闭TAB选项卡*/
            $(".tabs-inner").dblclick(function () {
                var subtitle = $(this).children(".tabs-closable").text();
                $('#tabs').tabs('close', subtitle);
            });
            /*为选项卡绑定右键*/
            $(".tabs-inner").bind('contextmenu', function (e) {
                $('#mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });

                var subtitle = $(this).children(".tabs-closable").text();

                $('#mm').data("currtab", subtitle);
                $('#tabs').tabs('select', subtitle);
                return false;
            });
        }
        //绑定右键菜单事件
        function tabCloseEven() {
            //刷新
            $('#mm-tabupdate').click(function () {
                var currTab = $('#tabs').tabs('getSelected');
                var url = $(currTab.panel('options').content).attr('src');
                if (url != undefined && currTab.panel('options').title != '我的桌面') {
                    $('#tabs').tabs('update', {
                        tab: currTab,
                        options: {
                            content: createFrame(url)
                        }
                    })
                }
            })
            //关闭当前
            $('#mm-tabclose').click(function () {
                var currtab_title = $('#mm').data("currtab");
                $('#tabs').tabs('close', currtab_title);
            })
            //全部关闭
            $('#mm-tabcloseall').click(function () {
                $('.tabs-inner span').each(function (i, n) {
                    var t = $(n).text();
                    if (t != '我的桌面') {
                        $('#tabs').tabs('close', t);
                    }
                });
            });
            //关闭除当前之外的TAB
            $('#mm-tabcloseother').click(function () {
                var prevall = $('.tabs-selected').prevAll();
                var nextall = $('.tabs-selected').nextAll();
                if (prevall.length > 0) {
                    prevall.each(function (i, n) {
                        var t = $('a:eq(0) span', $(n)).text();
                        if (t != '我的桌面') {
                            $('#tabs').tabs('close', t);
                        }
                    });
                }
                if (nextall.length > 0) {
                    nextall.each(function (i, n) {
                        var t = $('a:eq(0) span', $(n)).text();
                        if (t != '我的桌面') {
                            $('#tabs').tabs('close', t);
                        }
                    });
                }
                return false;
            });
            //关闭当前右侧的TAB
            $('#mm-tabcloseright').click(function () {
                var nextall = $('.tabs-selected').nextAll();
                if (nextall.length == 0) {
                    //msgShow('系统提示','后边没有啦~~','error');
                    alert('后边没有啦~~');
                    return false;
                }
                nextall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    $('#tabs').tabs('close', t);
                });
                return false;
            });
            //关闭当前左侧的TAB
            $('#mm-tabcloseleft').click(function () {
                var prevall = $('.tabs-selected').prevAll();
                if (prevall.length == 0) {
                    alert('到头了，前边没有啦~~');
                    return false;
                }
                prevall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    $('#tabs').tabs('close', t);
                });
                return false;
            });

            //退出
            $("#mm-exit").click(function () {
                $('#mm').menu('hide');
            });
        }

        $(function () {
            tabCloseEven();
            $('#tabIndex').find('a').click(function () {
                var $this = $(this);
                var href = $this.attr('src');
                var title = $this.text();
                addTab(title, href);
            });
        });

    </script>
    
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div region="center" id="mainPanle">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="我的桌面">
                <div id="tabIndex" style="overflow: auto; height:100%;width:100%;">
                    
                    <%--<iframe scrolling="auto" frameborder="0" border="0px" src="Shop/Products/ProductsList.aspx?SaleStatus=1" style="width: 100%; height: 99%;"></iframe>--%>

                    <div class="mallb-index">
                        <div class="outer_width">
                            <div class="newslistabout">
                                <div class="briefing">
                                    <div class="briefing-content briefing-column4">
                                        <div class="briefing-item">
                                            <div class="color-module module5">
                                                <span class="mallb-icon mallb-product"></span>
                                                <div class="m-r">
                                                    <div class="name">商品总数</div>
                                                    <div class="number" id="all"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="briefing-item">
                                            <div class="color-module module6">
                                                <span class="mallb-icon mallb-onsale"></span>
                                                <div class="m-r">
                                                    <div class="name">在售商品数</div>
                                                    <div class="number" id="sale"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="briefing-item">
                                            <div class="color-module module7">
                                                <span class="mallb-icon mallb-soldout"></span>
                                                <div class="m-r">
                                                    <div class="name">下架商品数</div>
                                                    <div class="number" id="unSale"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="briefing-item">
                                            <div class="color-module module8">
                                                <span class="mallb-icon mallb-collect"></span>
                                                <div class="m-r">
                                                    <div class="name">收藏商品数</div>
                                                    <div class="number" id="favor"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="def-wrapper rank-list mr10">
                                        <div class="def-item-title">
                                            <div class="def-title-txt title-bl">本月商品销量数（<span class="attention">TOP5</span>）</div>

                                        </div>
                                        <div class="rank-content">
                                            
                                            <div id="amountNoDate" runat="server">
                                                <span class="NoData">暂无数据</span>
                                            </div>

                                            <asp:Repeater ID="RepeaterAmount" runat="server">
                                                <ItemTemplate>
                                                    <div>
                                                        <div class="progress_item no<%# DataBinder.Eval(Container.DataItem,"Sequence") %>">
                                                            <div class="product-name"><%# DataBinder.Eval(Container.DataItem,"Name") %></div>
                                                            <div class="progress_title">
                                                                <div class="ranking">
                                                                    <div class="ranking-num"><%# DataBinder.Eval(Container.DataItem,"Sequence") %></div>
                                                                </div>
                                                            </div>
                                                            <div class="progress_bar_wrap">
                                                                <div class="progress_bar" style="width: <%# DataBinder.Eval(Container.DataItem,"Width") %>"></div>
                                                                <span class="number"><%# DataBinder.Eval(Container.DataItem,"Count") %></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>


                                        </div>
                                    </div>
                                    <div class="def-wrapper rank-list">
                                        <div class="def-item-title">
                                            <div class="def-title-txt title-bl">本月商品销售额排行（<span class="attention">TOP5</span>）</div>

                                        </div>
                                        <div class="rank-content">
                                            
                                            <div id="countNoDate" runat="server">
                                                <span class="NoData">暂无数据</span>
                                            </div>

                                            <asp:Repeater ID="RepeaterCount" runat="server">
                                                <ItemTemplate>
                                                    <div class="progress_item no<%# DataBinder.Eval(Container.DataItem,"Sequence") %>">
                                                        <div class="product-name"><%# DataBinder.Eval(Container.DataItem,"Name") %></div>
                                                        <div class="progress_title">
                                                            <div class="ranking">
                                                                <div class="ranking-num"><%# DataBinder.Eval(Container.DataItem,"Sequence") %></div>
                                                            </div>
                                                        </div>
                                                        <div class="progress_bar_wrap">
                                                            <div class="progress_bar" style="width: <%# DataBinder.Eval(Container.DataItem,"Width") %>"></div>
                                                            <span class="number"><%# DataBinder.Eval(Container.DataItem,"Amount") %></span>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    </form>
    <div id="mm" class="easyui-menu" style="width: 120px;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseother">
            关闭其他</div>
        <div id="mm-tabcloseall">
            关闭全部</div>
    </div>
    <input type="hidden" id="hidAllDepotStatsJson" runat="server" />
</body>
    <script type="text/javascript">
        $(function () {
            //if ($('.GridViewTyle').length == 0)
            //    $('.newslistabout:eq(0)').append('<table width="100%" border="0" cellspacing="0" cellpadding="0" class="borderkuang"><tbody><tr><td bgcolor="#FFFFFF" class="newstitle">暂无数据</td></tr></tbody></table>');
            $.ajax({
                url: ("main_index2.aspx?timestamp={0}").format(new Date().getTime()),
                type: 'POST', dataType: 'json', timeout: 10000,
                data: { Action: "GetDate", Callback: "true" },
                success: function (resultData) {
                    if (resultData.STATUS == "SUCCESS") {
                        $("#all").text(resultData.ALL);
                        $("#sale").text(resultData.SALE);
                        $("#unSale").text(resultData.UNSALE);
                        $("#favor").text(resultData.FAVOR);
                    }
                    else {
                        alert("系统忙请稍后再试！");
                    }
                }
            });

        });
    </script>
</html>
