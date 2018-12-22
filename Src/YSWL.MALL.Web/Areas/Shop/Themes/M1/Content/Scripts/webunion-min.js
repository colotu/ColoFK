var urp = [],
urpv = [],
arrayCount = 0,
sEn = [],
keyWord = [];
sEn = ["baidu", "google", "sogou", "soso", "youdao", "yahoo", "bing"];
keyWord = ["wd", "q", "query", "w", "q", "p", "q"];
var pageOpen = new Date,
uexp = pageOpen.getTime() + 864E5;
function getKeyword(b) {
    b = getHostName(b);
    for (var c = 0; c < sEn.length; c++) if (b == sEn[c]) for (var a = 0; a < urp.length; a++) if (urp[a] == keyWord[c]) return b + "-" + urpv[a];
    return ""
}
function getHostName(b) {
    return b.indexOf(".") == -1 ? b : b.match(/\.([^\/]+?)\./i)[0].replace(".", "").replace(".", "")
}
function setCookie(b, c) {
    var a = new Date;
    if (15768E3 != null) {
        a.setTime(uexp);
        document.cookie = b + "=" + escape(c) + (15768E3 == null ? "" : "; expires=" + a.toGMTString()) + "" + (".maticsoft" == null ? "" : "; domain=.maticsoft") + ""
    }
}
function gethn(b) {
    if (!b || b == "") return "";
    ur = b;
    if (ur.indexOf("?") != -1) {
        for (var c = ur.substring(0, ur.indexOf("?")), a = ur.substring(ur.indexOf("?") + 1, ur.length); a.length > 0; ) {
            if (a.indexOf("&") == -1) {
                urp[arrayCount] = a.substring(0, a.indexOf("="));
                urpv[arrayCount] = a.substring(a.indexOf("=") + 1, a.length);
                break
            }
            b = a.substring(0, a.indexOf("&"));
            urp[arrayCount] = b.substring(0, b.indexOf("="));
            urpv[arrayCount] = b.substring(b.indexOf("=") + 1, b.length);
            a = a.substring(a.indexOf("&") + 1, a.length);
            arrayCount++
        }
        return c
    } else if (ur.indexOf("#") != -1) getHostName(ur) == "google" && gethn(ur.replace("#", "?"));
    else return ur
}
