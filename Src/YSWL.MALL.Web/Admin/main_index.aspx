<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_index.aspx.cs" Inherits="YSWL.MALL.Web.Admin.main_index" %>

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
    <script type="text/javascript">
        $(document).ready(function () {
          
            var hfCategoryVal = $("[id$='createdDate']").val();
            if (hfCategoryVal.length <= 0) {
                return;
            }
            hfCategoryVal = hfCategoryVal.replace(/\d{4}-/g, '');
            var categories = hfCategoryVal.split(',');

            var dayCount = [];

            var datavalue = $("[id$='amount']").val().split(',');
            for (var i = 0; i < datavalue.length; i++) {
                var item = parseFloat(datavalue[i]);
                dayCount.push(item);
            }
            $('#orderCount').highcharts({
                chart: {
                    type: 'line'
                },
                title: {
                    text: '销售额统计'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: categories
                },
                yAxis: {
                    title: {
                        text: '销售额'
                    },
                    min:0
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.x + '：</b>' + this.y + '元';
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true
                    }
                },
                series: [{
                    name: '销售额',
                    data: dayCount
                }]
            });

            $("#priceCount text:last").hide();
            $("#priceCount span:last").hide();

            //if ($('#priceCount .highcharts-tracker rect').length > 0) {
            //    if (parseInt($('#priceCount .highcharts-tracker rect').eq(0).attr('width')) > 25) {
            //        $('#priceCount .highcharts-tracker rect').css('width', '25px');
            //    }
            //}

            //控制线条宽度   最高为25  
            var rec_s = $('#priceCount .highcharts-tracker rect');
            if (rec_s.length > 0) {
                var rect_width = parseInt(rec_s.eq(0).attr('width'));
                var x_ = (rect_width - 25) / 2;//计算新的X轴位置
                if (rect_width > 25) {
                    for (var i = 0; i < rec_s.length; i++) {
                        rec_s.eq(i).css('width', '25px').attr('x', parseFloat(rec_s.eq(i).attr('x')) + x_);
                    }
                }
            }
            //统计
            if ($("[id$='hidAllDepotStatsJson']").val() != null && $("[id$='hidAllDepotStatsJson']").val().length > 0) {
                var allDepotStatsJson = $.parseJSON(($("[id$='hidAllDepotStatsJson']").val()));
                var trHtml = '<tr><td>{0}</td><td style="display:none">VIP</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>';
                var s_html = '';
                for (var i = 0; i < allDepotStatsJson.length; i++) {
                    s_html = trHtml.format(allDepotStatsJson[i].BuyerName, allDepotStatsJson[i].TotalAmount, allDepotStatsJson[i].orderCount, allDepotStatsJson[i].GetPaidAmount, allDepotStatsJson[i].GetUnPaidAmount);

                    $('#table_AllDepotStats').append(s_html);
                }
            }
        });

    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div region="center" id="mainPanle">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="我的桌面">
                <div id="tabIndex" style="overflow: scroll; overflow-x: hidden; overflow-y: hidden;height:100%;width:100%;">
                    
                    <iframe scrolling="auto" frameborder="0" border="0px" src="Shop/Products/ProductsList.aspx?SaleStatus=1" style="width: 100%; height: 99%;"></iframe>
                    <div class="saas_dinghuo_wrap" style="display: none">
		<div class="saas_dinghuo_content1">
				<table class="table_item fl dinghuo_table">
					<tr>
						<th></th>
						<th>订单数</th>
						<th>订单金额</th>
					</tr>

					<tr>
						<td>今日</td>
						<td><asp:Label ID="lblOrderToday" runat="server" Text="Label"></asp:Label></td>
						<%--<td><asp:Label ID="lblSaleToday" runat="server" Text="Label"></asp:Label></td>--%>
					</tr>
					<tr>
						<td>七日</td>
						<td><asp:Label ID="lblOrderWeek" runat="server" Text="Label"></asp:Label></td>
						<td><asp:Label ID="lblSaleWeek" runat="server" Text="Label"></asp:Label></td>
					</tr>
					<tr>
						<td>本月</td>
						<td><asp:Label ID="lblOrderMon" runat="server" Text="Label"></asp:Label></td>
						<td><asp:Label ID="lblSaleMon" runat="server" Text="Label"></asp:Label></td>
					</tr>
				</table>
				<table class="table_item fl dinghuo_table ">
					<tr>
						<th>待处理订单</th>
						<th></th>
					</tr>

					<tr>
						<td>待付款订单</td>
						<td><asp:Label ID="lblUnPayOrder" runat="server" Text="Label"></asp:Label></td>
					</tr>
					<tr>
						<td>待发货订单</td>
						<td><asp:Label ID="lblUnfilledOrder" runat="server" Text="Label"></asp:Label></td>
					</tr>
					<tr>
						<td>待收货订单</td>
						<td><asp:Label ID="lblShippedOrder" runat="server" Text="Label"></asp:Label></td>
					</tr>
				</table>
				<table class="table_item fl dinghuo_table">
					<tr>
						<th>商品</th>
						<th></th>
					</tr>

					<tr>
						<td>上架商品数</td>
						<td><asp:Label ID="lblItemUpshelf" runat="server" Text="Label"></asp:Label></td>
					</tr>
					<tr>
						<td>下架商品数</td>
						<td><asp:Label ID="lblItemDownshelf" runat="server" Text="Label"></asp:Label></td>
					</tr>
				</table>
		</div>
     <asp:HiddenField ID="createdDate" runat="server" />
    <asp:HiddenField ID="amount" runat="server" />
		<div class="saas_ydh_content2">
			<div class="saas_title">
				<h2 class="color_grey saas_title_h2">销售额统计</h2>
			</div>
			<div class="saas_chart" id="orderCount">
			
			</div>
		</div>
		<div class="saas_ydh_content3">
			<div class="saas_title">
				<h2 class="color_grey saas_title_h2">月客户订货排行TOP10</h2>
			</div>
			<table class="table_item" id="table_AllDepotStats">
				<tr>
					<th>客户名称</th>
					<th style="display:none">客户等级</th>
					<th>订货金额</th>
					<th>订单数</th>
					<th>已付款金额</th>
					<th>未付款金额</th>
				</tr>
				
			</table>
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
    
</html>
