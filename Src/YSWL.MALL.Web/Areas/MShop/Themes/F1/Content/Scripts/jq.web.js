(function (b) {
    var h = [];
    b.fn.carousel = function (e) {
        for (var k, m, d = 0; d < this.length; d++) {
            k = this[d];
            if (!k.jqmCarouselId) k.jqmCarouselId = b.uuid();
            m = k.jqmCarouselId;
            h[m] ? k = h[m] : (k = new g(this[d], e), h[m] = k)
        }
        return this.length == 1 ? k : this
    };
    var g = function () {
        var e = b.feat.cssTransformStart,
        k = b.feat.cssTransformEnd,
        g = function (d, f) {
            if (this.container = typeof d === "string" || d instanceof String ? document.getElementById(d) : d) {
                if (this instanceof g) for (var c in f) f.hasOwnProperty(c) && (this[c] = f[c]);
                else return new g(d, f);
                var i = this;
                jq(this.container).bind("destroy",
                function (a) {
                    var c = i.container.jqmCarouselId;
                    window.removeEventListener("orientationchange", i.orientationHandler, !1);
                    h[c] && delete h[c];
                    a.stopPropagation()
                });
                this.pagingDiv = this.pagingDiv ? document.getElementById(this.pagingDiv) : null;
                this.container.style.overflow = "hidden";
                if (this.vertical) this.horizontal = !1;
                c = document.createElement("div");
                this.container.appendChild(c);
                for (var l = b(c), e = b(this.container), a = Array.prototype.slice.call(this.container.childNodes); a.length > 0; ) {
                    var o = a.splice(0, 1),
                    o = e.find(o);
                    o.get() != c && l.append(o.get())
                }
                this.horizontal ? (c.style.display = "block", c.style["float"] = "left") : c.style.display = "block";
                this.el = c;
                this.refreshItems();
                c = jq(c);
                c.bind("touchmove",
                function (a) {
                    i.touchMove(a)
                });
                c.bind("touchend",
                function (a) {
                    i.touchEnd(a)
                });
                c.bind("touchstart",
                function (a) {
                    i.touchStart(a)
                });
                this.orientationHandler = function () {
                    i.onMoveIndex(i.carouselIndex, 0)
                };
                window.addEventListener("orientationchange", this.orientationHandler, !1)
            } else alert("Error finding container for carousel " + d)
        };
        g.prototype = {
            startX: 0,
            startY: 0,
            dx: 0,
            dy: 0,
            glue: !1,
            myDivWidth: 0,
            myDivHeight: 0,
            cssMoveStart: 0,
            childrenCount: 0,
            carouselIndex: 0,
            vertical: !1,
            horizontal: !0,
            el: null,
            movingElement: !1,
            container: null,
            pagingDiv: null,
            pagingCssName: "carousel_paging",
            pagingCssNameSelected: "carousel_paging_selected",
            pagingFunction: null,
            lockMove: !1,
            okToMove: !1,
            touchStart: function (d) {
                this.okToMove = !1;
                this.myDivWidth = numOnly(this.container.clientWidth);
                this.myDivHeight = numOnly(this.container.clientHeight);
                this.lockMove = !1;
                if (d.touches[0].target && d.touches[0].target.type !== void 0) {
                    var f = d.touches[0].target.tagName.toLowerCase();
                    if (f === "select" || f === "input" || f === "button") return
                }
                if (d.touches.length === 1) if (this.movingElement = !0, this.startY = d.touches[0].pageY, this.startX = d.touches[0].pageX, d = b.getCssMatrix(this.el), this.vertical) try {
                    this.cssMoveStart = numOnly(d.f)
                } catch (c) {
                    this.cssMoveStart = 0
                } else try {
                    this.cssMoveStart = numOnly(d.e)
                } catch (i) {
                    this.cssMoveStart = 0
                }
            },
            touchMove: function (d) {
                if (this.movingElement) {
                    if (d.touches.length > 1) return this.touchEnd(d);
                    var f = {
                        x: d.touches[0].pageX - this.startX,
                        y: d.touches[0].pageY - this.startY
                    };
                    if (this.vertical) f = {
                        x: 0,
                        y: 0
                    },
                    this.dy = d.touches[0].pageY - this.startY,
                    this.dy += this.cssMoveStart,
                    f.y = this.dy,
                    d.preventDefault();
                    else {
                        var c;
                        if (c = !this.lockMove) f = Math.round(Math.atan2(f.y, f.x) * 180 / Math.PI),
                        f < 0 && (f = 360 - Math.abs(f)),
                        c = f <= 215 && f >= 155 || f <= 45 && f >= 0 || f <= 360 && f >= 315 ? !0 : !1;
                        if (c) f = {
                            x: 0,
                            y: 0
                        },
                        this.dx = d.touches[0].pageX - this.startX,
                        this.dx += this.cssMoveStart,
                        d.preventDefault(),
                        f.x = this.dx;
                        else return this.lockMove = !0
                    }
                    d = this.vertical ? this.dy % this.myDivHeight / this.myDivHeight * -100 : this.dx % this.myDivWidth / this.myDivWidth * -100;
                    if (!this.okToMove) oldStateOkToMove = this.okToMove,
                    (this.okToMove = this.glue ? Math.abs(d) > this.glue && Math.abs(d) < 100 - this.glue : !0) && !oldStateOkToMove && b.trigger(this, "movestart", [this.el]);
                    this.okToMove && f && this.moveCSS3(this.el, f)
                }
            },
            touchEnd: function () {
                if (this.movingElement) {
                    b.trigger(this, "movestop", [this.el]);
                    var d = !1;
                    try {
                        var f = b.getCssMatrix(this.el),
                        c = this.vertical ? numOnly(f.f) : numOnly(f.e),
                        i = this.vertical ? this.dy % this.myDivHeight / this.myDivHeight * -100 : this.dx % this.myDivWidth / this.myDivWidth * -100,
                        l = this.carouselIndex;
                        c < this.cssMoveStart && i > 3 ? l++ : c > this.cssMoveStart && i < 97 && l--;
                        f = l;
                        if (l > this.childrenCount - 1) l = 0,
                        f = this.childrenCount;
                        l < 0 && (l = this.childrenCount - 1, f = -1);
                        c = {
                            x: 0,
                            y: 0
                        };
                        this.vertical ? c.y = f * this.myDivHeight * -1 : c.x = f * this.myDivWidth * -1;
                        this.moveCSS3(this.el, c, "150");
                        if (this.pagingDiv && this.carouselIndex !== l) document.getElementById(this.container.id + "_" + this.carouselIndex).className = this.pagingCssName,
                        document.getElementById(this.container.id + "_" + l).className = this.pagingCssNameSelected;
                        this.carouselIndex != l && (d = !0);
                        this.carouselIndex = l;
                        if (f != l) {
                            var e = this;
                            window.setTimeout(function () {
                                e.onMoveIndex(l, "1ms")
                            },
                            155)
                        }
                    } catch (a) {
                        console.log(a)
                    }
                    this.dx = 0;
                    this.movingElement = !1;
                    this.startY = this.dy = this.startX = 0;
                    d && this.pagingFunction && typeof this.pagingFunction == "function" && this.pagingFunction(this.carouselIndex)
                }
            },
            onMoveIndex: function (b, f) {
                this.myDivWidth = numOnly(this.container.clientWidth);
                this.myDivHeight = numOnly(this.container.clientHeight);
                var c = !1;
                if (document.getElementById(this.container.id + "_" + this.carouselIndex)) document.getElementById(this.container.id + "_" + this.carouselIndex).className = this.pagingCssName;
                var i = Math.abs(b - this.carouselIndex),
                l = b;
                l < 0 && (l = 0);
                l > this.childrenCount - 1 && (l = this.childrenCount - 1);
                var e = {
                    x: 0,
                    y: 0
                };
                this.vertical ? e.y = l * this.myDivHeight * -1 : e.x = l * this.myDivWidth * -1;
                i = f ? f : 50 + parseInt(i * 20);
                this.moveCSS3(this.el, e, i);
                this.carouselIndex != l && (c = !0);
                this.carouselIndex = l;
                if (this.pagingDiv && (l = document.getElementById(this.container.id + "_" + this.carouselIndex))) l.className = this.pagingCssNameSelected;
                c && this.pagingFunction && typeof this.pagingFunction == "function" && this.pagingFunction(currInd)
            },
            moveCSS3: function (d, f, c, i) {
                c = c ? parseInt(c) : 0;
                i || (i = "linear");
                d.style[b.feat.cssPrefix + "Transform"] = "translate" + e + f.x + "px," + f.y + "px" + k;
                d.style[b.feat.cssPrefix + "TransitionDuration"] = c + "ms";
                d.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden";
                d.style[b.feat.cssPrefix + "TransformStyle"] = "preserve-3d";
                d.style[b.feat.cssPrefix + "TransitionTimingFunction"] = i
            },
            addItem: function (b) {
                b && b.nodeType && (this.container.childNodes[0].appendChild(b), this.refreshItems())
            },
            refreshItems: function () {
                var d = 0,
                f = this,
                c = this.el;
                b(c).find(".prevBuffer").remove();
                b(c).find(".nextBuffer").remove();
                n = c.childNodes[0];
                for (var i, l = []; n; n = n.nextSibling) n.nodeType === 1 && (l.push(n), d++);
                var e = b(l[l.length - 1]).clone().get(0);
                e.className = "prevBuffer";
                b(c).prepend(e);
                var a = b(l[0]).clone().get(0);
                a.className = "nextBuffer";
                b(c).append(a);
                l.push(a);
                l.unshift(e);
                this.childrenCount = d;
                i = parseFloat(100 / d) + "%";
                for (d = 0; d < l.length; d++) this.horizontal ? (l[d].style.width = i, l[d].style.height = "100%", l[d].style["float"] = "left") : (l[d].style.height = i, l[d].style.width = "100%", l[d].style.display = "block");
                a.style.position = "absolute";
                e.style.position = "absolute";
                this.moveCSS3(c, {
                    x: 0,
                    y: 0
                });
                this.horizontal ? (c.style.width = Math.ceil(this.childrenCount * 100) + "%", c.style.height = "100%", c.style["min-height"] = "100%", e.style.left = "-" + i, a.style.left = "100%") : (c.style.width = "100%", c.style.height = Math.ceil(this.childrenCount * 100) + "%", c.style["min-height"] = Math.ceil(this.childrenCount * 100) + "%", e.style.top = "-" + i, a.style.top = "100%");
                if (this.pagingDiv) {
                    this.pagingDiv.innerHTML = "";
                    for (d = 0; d < this.childrenCount; d++) c = document.createElement("div"),
                    c.id = this.container.id + "_" + d,
                    c.pageId = d,
                    c.className = d !== this.carouselIndex ? this.pagingCssName : this.pagingCssNameSelected,
                    c.onclick = function () {
                        f.onMoveIndex(this.pageId)
                    },
                    l = document.createElement("div"),
                    l.style.width = "20px",
                    this.horizontal ? (l.style.display = "inline-block", l.innerHTML = "&nbsp;") : (l.innerHTML = "&nbsp;", l.style.display = "block"),
                    this.pagingDiv.appendChild(c),
                    d + 1 < this.childrenCount && this.pagingDiv.appendChild(l),
                    l = c = null;
                    this.horizontal ? (this.pagingDiv.style.width = this.childrenCount * 50 + "px", this.pagingDiv.style.height = "25px") : (this.pagingDiv.style.height = this.childrenCount * 50 + "px", this.pagingDiv.style.width = "25px")
                }
                this.onMoveIndex(this.carouselIndex)
            }
        };
        return g
    } ()
})(jq); (function (b) {
    var h = [],
    g = function (f, c) {
        var i, e;
        i = typeof f == "string" || f instanceof String ? document.getElementById(f) : b.is$$(f) ? f[0] : f;
        if (!i.jqmCSS3AnimateId) i.jqmCSS3AnimateId = b.uuid();
        e = i.jqmCSS3AnimateId;
        h[e] ? (h[e].animate(c), i = h[e]) : (i = d(i, c), h[e] = i);
        return i
    };
    b.fn.css3Animate = function (b) {
        if (!b.complete && b.callback) b.complete = b.callback;
        var c = g(this[0], b);
        b.complete = null;
        b.sucess = null;
        b.failure = null;
        for (var d = 1; d < this.length; d++) c.link(this[d], b);
        return c
    };
    b.css3AnimateQueue = function () {
        return new d.queue
    };
    var e = b.feat.cssTransformStart,
    k = b.feat.cssTransformEnd,
    m = b.feat.cssPrefix.replace(/-/g, "") + "TransitionEnd",
    m = b.os.fennec || b.feat.cssPrefix == "" || b.os.ie ? "transitionend" : m,
    m = m.replace(m.charAt(0), m.charAt(0).toLowerCase()),
    d = function () {
        var d = function (c, i) {
            if (!(this instanceof d)) return new d(c, i);
            this.callbacksStack = [];
            this.activeEvent = null;
            this.countStack = 0;
            this.isActive = !1;
            this.el = c;
            this.linkFinishedProxy_ = b.proxy(this.linkFinished, this);
            if (this.el) {
                this.animate(i);
                var e = this;
                jq(this.el).bind("destroy",
                function () {
                    var b = e.el.jqmCSS3AnimateId;
                    e.callbacksStack = [];
                    h[b] && delete h[b]
                })
            }
        };
        d.prototype = {
            animate: function (c) {
                this.isActive && this.cancel();
                this.isActive = !0;
                if (c) {
                    var d = !!c.addClass;
                    if (d) c.removeClass ? jq(this.el).replaceClass(c.removeClass, c.addClass) : jq(this.el).addClass(c.addClass);
                    else {
                        var f = numOnly(c.time);
                        f == 0 && (c.time = 0);
                        c.y || (c.y = 0);
                        c.x || (c.x = 0);
                        if (c.previous) {
                            var g = new b.getCssMatrix(this.el);
                            c.y += numOnly(g.f);
                            c.x += numOnly(g.e)
                        }
                        if (!c.origin) c.origin = "0% 0%";
                        if (!c.scale) c.scale = "1";
                        if (!c.rotateY) c.rotateY = "0";
                        if (!c.rotateX) c.rotateX = "0";
                        if (!c.skewY) c.skewY = "0";
                        if (!c.skewX) c.skewX = "0";
                        c.timingFunction || (c.timingFunction = "linear");
                        if (typeof c.x == "number" || c.x.indexOf("%") == -1 && c.x.toLowerCase().indexOf("px") == -1 && c.x.toLowerCase().indexOf("deg") == -1) c.x = parseInt(c.x) + "px";
                        if (typeof c.y == "number" || c.y.indexOf("%") == -1 && c.y.toLowerCase().indexOf("px") == -1 && c.y.toLowerCase().indexOf("deg") == -1) c.y = parseInt(c.y) + "px";
                        g = "translate" + e + c.x + "," + c.y + k + " scale(" + parseFloat(c.scale) + ") rotate(" + c.rotateX + ")";
                        b.os.opera || (g += " rotateY(" + c.rotateY + ")");
                        g += " skew(" + c.skewX + "," + c.skewY + ")";
                        this.el.style[b.feat.cssPrefix + "Transform"] = g;
                        this.el.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden";
                        g = b.feat.cssPrefix + "Transform";
                        if (c.opacity !== void 0) this.el.style.opacity = c.opacity,
                        g += ", opacity";
                        if (c.width) this.el.style.width = c.width,
                        g = "all";
                        if (c.height) this.el.style.height = c.height,
                        g = "all";
                        this.el.style[b.feat.cssPrefix + "TransitionProperty"] = "all";
                        if (("" + c.time).indexOf("s") === -1) var g = "ms",
                        a = c.time + g;
                        else c.time.indexOf("ms") !== -1 ? (g = "ms", a = c.time) : (g = "s", a = c.time + g);
                        this.el.style[b.feat.cssPrefix + "TransitionDuration"] = a;
                        this.el.style[b.feat.cssPrefix + "TransitionTimingFunction"] = c.timingFunction;
                        this.el.style[b.feat.cssPrefix + "TransformOrigin"] = c.origin
                    }
                    this.callbacksStack.push({
                        complete: c.complete,
                        success: c.success,
                        failure: c.failure
                    });
                    this.countStack++;
                    var o = this,
                    a = window.getComputedStyle(this.el);
                    if (d) d = a[b.feat.cssPrefix + "TransitionDuration"],
                    f = numOnly(d),
                    c.time = f,
                    d.indexOf("ms") !== -1 ? g = "ms" : (c.time *= 1E3, g = "s");
                    f == 0 || g == "ms" && f < 5 || a.display == "none" ? b.asap(b.proxy(this.finishAnimation, this, [!1])) : (o = this, this.activeEvent = function (a) {
                        clearTimeout(o.timeout);
                        o.finishAnimation(a);
                        o.el.removeEventListener(m, o.activeEvent, !1)
                    },
                    o.timeout = setTimeout(this.activeEvent, numOnly(c.time) + 50), this.el.addEventListener(m, this.activeEvent, !1))
                } else alert("Please provide configuration options for animation of " + this.el.id)
            },
            addCallbackHook: function (b) {
                b && this.callbacksStack.push(b);
                this.countStack++;
                return this.linkFinishedProxy_
            },
            linkFinished: function (b) {
                b ? this.cancel() : this.finishAnimation()
            },
            finishAnimation: function (b) {
                b && b.preventDefault();
                this.isActive && (this.countStack--, this.countStack == 0 && this.fireCallbacks(!1))
            },
            fireCallbacks: function (b) {
                this.clearEvents();
                var d = this.callbacksStack;
                this.cleanup();
                for (var f = 0; f < d.length; f++) {
                    var e = d[f].complete,
                    a = d[f].success,
                    o = d[f].failure;
                    e && typeof e == "function" && e(b);
                    b && o && typeof o == "function" ? o() : a && typeof a == "function" && a()
                }
            },
            cancel: function () {
                this.isActive && this.fireCallbacks(!0)
            },
            cleanup: function () {
                this.callbacksStack = [];
                this.isActive = !1;
                this.countStack = 0
            },
            clearEvents: function () {
                this.activeEvent && this.el.removeEventListener(m, this.activeEvent, !1);
                this.activeEvent = null
            },
            link: function (b, d) {
                var f = {
                    complete: d.complete,
                    success: d.success,
                    failure: d.failure
                };
                d.complete = this.addCallbackHook(f);
                d.success = null;
                d.failure = null;
                g(b, d);
                d.complete = f.complete;
                d.success = f.success;
                d.failure = f.failure;
                return this
            }
        };
        return d
    } ();
    d.queue = function () {
        return {
            elements: [],
            push: function (b) {
                this.elements.push(b)
            },
            pop: function () {
                return this.elements.pop()
            },
            run: function () {
                var b = this;
                if (this.elements.length != 0 && (typeof this.elements[0] == "function" && this.shift()(), this.elements.length != 0)) {
                    var c = this.shift();
                    if (this.elements.length > 0) c.complete = function (d) {
                        d || b.run()
                    };
                    d(document.getElementById(c.id), c)
                }
            },
            shift: function () {
                return this.elements.shift()
            }
        }
    }
})(jq); (function (b) {
    b.fn.drawer = function (b) {
        for (var e, k = 0; k < this.length; k++) e = new h(this[k], b);
        return this.length == 1 ? e : this
    };
    var h = function () {
        var g = b.feat.cssTransformStart,
        e = b.feat.cssTransformEnd,
        k = !1,
        h = function (d, f) {
            if (this.el = typeof d == "string" || d instanceof String ? document.getElementById(d) : d) {
                if (this instanceof h) for (j in f) this[j] = f[j];
                else return new h(d, f);
                this.direction = this.direction.toLowerCase();
                try {
                    this.handle = this.el.querySelectorAll(".drawer_handle")[0];
                    if (!this.handle) return alert("Could not find handle for drawer -  " + d);
                    var c = this;
                    this.handle.addEventListener("touchmove",
                    function (b) {
                        c.touchMove(b)
                    },
                    !1);
                    this.handle.addEventListener("touchend",
                    function (b) {
                        c.touchEnd(b)
                    },
                    !1)
                } catch (e) {
                    alert("error adding drawer" + e)
                }
                this.zIndex = b(this.el).css("zIndex")
            } else alert("Could not find element for drawer " + d)
        };
        h.prototype = {
            lockY: 0,
            lockX: 0,
            boolScrollLock: !1,
            currentDrawer: null,
            maxTop: 0,
            startTop: 0,
            maxLeft: 0,
            startLeft: 0,
            timeMoved: 0,
            vdistanceMoved: 0,
            hdistanceMoved: 0,
            direction: "down",
            prevTime: 0,
            handle: null,
            zIndex: 1,
            touchMove: function (d) {
                try {
                    if (k || (k = !0, this.touchStart(d)), this.currentDrawer != null) {
                        d.preventDefault();
                        var f = {
                            x: 0,
                            y: 0
                        };
                        if (this.direction == "down" || this.direction == "up") {
                            var c = 0,
                            e = 0,
                            g = this.lockY - d.touches[0].pageY,
                            g = -g,
                            c = this.startTop + g;
                            try {
                                e = numOnly(b.getCssMatrix(this.el).f)
                            } catch (h) {
                                e = 0
                            }
                            f.y = c;
                            this.vdistanceMoved += Math.abs(e) - Math.abs(c)
                        } else {
                            e = g = 0;
                            c = this.lockX - d.touches[0].pageX;
                            c = -c;
                            g = this.startLeft + c;
                            try {
                                e = numOnly(b.getCssMatrix(this.el).e)
                            } catch (a) {
                                e = 0
                            }
                            f.x = g;
                            this.hdistanceMoved += Math.abs(e) - Math.abs(g)
                        }
                        this.drawerMove(this.currentDrawer, f, 0)
                    }
                } catch (o) {
                    alert("error in scrollMove: " + o)
                }
            },
            touchStart: function (d) {
                var f = this.el;
                if (this.handle) try {
                    if (d.touches[0].target && d.touches[0].target.type != void 0) {
                        var c = d.touches[0].target.tagName.toLowerCase();
                        if (c == "select" || c == "input" || c == "button") return
                    }
                    this.hdistanceMoved = this.vdistanceMoved = 0;
                    this.maxTop = numOnly(this.el.style.height) - numOnly(this.handle.style.height);
                    this.maxLeft = numOnly(this.el.style.width) - numOnly(this.handle.style.width);
                    this.direction == "up" && (this.maxTop *= -1);
                    this.direction == "left" && (this.maxLeft *= -1);
                    if (d.touches.length == 1 && this.boolScrollLock == !1) {
                        try {
                            this.startTop = numOnly(b.getCssMatrix(this.el).f),
                            this.startLeft = numOnly(b.getCssMatrix(this.el).e)
                        } catch (e) {
                            this.startLeft = this.startTop = 0,
                            console.log("error drawer touchstart " + e)
                        }
                        this.lockY = d.touches[0].pageY;
                        this.lockX = d.touches[0].pageX;
                        this.currentDrawer = f;
                        d.preventDefault()
                    }
                } catch (g) {
                    alert("error in drawer start: " + g)
                }
            },
            touchEnd: function (d) {
                if (this.currentDrawer != null) {
                    d.preventDefault();
                    d.stopPropagation();
                    d = {
                        x: 0,
                        y: 0
                    };
                    if (this.direction == "up" || this.direction == "down") {
                        var e = -this.vdistanceMoved,
                        c = Math.ceil(Math.abs(e) / Math.abs(this.maxTop) * 100),
                        g = numOnly(b.getCssMatrix(this.el).f);
                        d.y = c > 17 ? e > 0 ? this.maxTop : 0 : Math.floor(this.maxTop / g) > 2 ? 0 : this.maxTop
                    } else e = -this.hdistanceMoved,
                    c = Math.ceil(Math.abs(e) / Math.abs(this.maxLeft) * 100),
                    g = numOnly(b.getCssMatrix(this.el).e),
                    c > 17 ? d.x = e > 0 ? this.maxLeft : 0 : Math.floor(this.maxLeft / g) > 2 ? d.y = 0 : d.x = this.maxLeft;
                    this.el.zIndex = d.y > 0 || d.x > 0 ? "9999" : this.zIndex;
                    this.drawerMove(this.currentDrawer, d, 300, "ease-out");
                    this.currentDrawer = null
                }
                this.vdistanceMoved = 0;
                k = !1
            },
            drawerMove: function (d, f, c, i) {
                c || (c = 0);
                i || (i = "linear");
                d.style[b.feat.cssPrefix + "Transform"] = "translate" + g + f.x + "px," + f.y + "px" + e;
                d.style[b.feat.cssPrefix + "TransitionDuration"] = c + "ms";
                d.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden";
                d.style[b.feat.cssPrefix + "TransformStyle"] = "preserve-3d";
                d.style[b.feat.cssPrefix + "TransitionTimingFunction"] = i
            }
        };
        return h
    } ()
})(jq); (function (b) {
    b.passwordBox = function () {
        return new h
    };
    var h = function () {
        this.oldPasswords = {}
    };
    h.prototype = {
        showPasswordPlainText: !1,
        getOldPasswords: function (g) {
            var e = g && document.getElementById(g) ? document.getElementById(g) : document;
            if (e) {
                g = e.getElementsByTagName("input");
                for (e = 0; e < g.length; e++) if (g[e].type == "password" && b.os.webkit) g[e].type = "text",
                g[e].style["-webkit-text-security"] = "disc"
            } else alert("Could not find container element for passwordBox " + g)
        },
        changePasswordVisiblity: function (g, e) {
            var g = parseInt(g),
            k = document.getElementById(e);
            k.style[b.cssPrefix + "text-security"] = g == 1 ? "none" : "disc";
            if (!b.os.webkit) k.type = g == 1 ? "text" : "password"
        }
    }
})(jq); (function (b) {
    function h(b) {
        if (!e[b].el) return delete e[b],
        !1;
        return !0
    }
    function g() {
        if (jq.os.android && !jq.os.chrome && jq.os.webkit) {
            var d = !1;
            b.bind(b.touchLayer, "pre-enter-edit",
            function (b) {
                if (!d) for (el in d = !0, e) h(el) && e[el].needsFormsFix(b) && e[el].startFormsMode()
            });
            b.bind(b.touchLayer, ["cancel-enter-edit", "exit-edit"],
            function () {
                if (d) for (el in d = !1, e) h(el) && e[el].androidFormsMode && e[el].stopFormsMode()
            })
        }
        k = !0
    }
    var e = [];
    b.fn.scroller = function (d) {
        for (var f, c, g = 0; g < this.length; g++) {
            f = this[g];
            if (!f.jqmScrollerId) f.jqmScrollerId = b.uuid();
            c = f.jqmScrollerId;
            if (e[c]) f = e[c];
            else {
                d || (d = {});
                if (!b.feat.nativeTouchScroll) d.useJsScroll = !0;
                f = m(this[g], d);
                e[c] = f
            }
        }
        return this.length == 1 ? f : this
    };
    var k = !1,
    m = function () {
        function d(a, d) {
            var c = document.createElement("div");
            c.style.position = "absolute";
            c.style.width = a + "px";
            c.style.height = d + "px";
            c.style[b.feat.cssPrefix + "BorderRadius"] = "2px";
            c.style.borderRadius = "2px";
            c.style.opacity = 0;
            c.className = "scrollBar";
            c.style.background = "black";
            return c
        }
        var f = b.feat.cssTransformStart,
        c = b.feat.cssTransformEnd,
        i, h, m = function (a, c) {
            this.el = a;
            this.jqEl = b(this.el);
            for (j in c) this[j] = c[j]
        };
        m.prototype = {
            refresh: !1,
            refreshContent: "Pull to Refresh",
            refreshHangTimeout: 2E3,
            refreshHeight: 60,
            refreshElement: null,
            refreshCancelCB: null,
            refreshRunning: !1,
            scrollTop: 0,
            scrollLeft: 0,
            preventHideRefresh: !0,
            verticalScroll: !0,
            horizontalScroll: !1,
            refreshTriggered: !1,
            moved: !1,
            eventsActive: !1,
            rememberEventsActive: !1,
            scrollingLocked: !1,
            autoEnable: !0,
            blockFormsFix: !1,
            loggedPcentY: 0,
            loggedPcentX: 0,
            infinite: !1,
            infiniteEndCheck: !1,
            infiniteTriggered: !1,
            scrollSkip: !1,
            scrollTopInterval: null,
            scrollLeftInterval: null,
            _scrollTo: function (a, b) {
                b = parseInt(b);
                if (b == 0 || isNaN(b)) this.el.scrollTop = Math.abs(a.y),
                this.el.scrollLeft = Math.abs(a.x);
                else {
                    var c = (this.el.scrollTop - a.y) / Math.ceil(b / 10),
                    d = (this.el.scrollLeft - a.x) / Math.ceil(b / 10),
                    e = this,
                    f = Math.ceil(this.el.scrollTop - a.y) / c,
                    g = Math.ceil(this.el.scrollLeft - a.x) / c,
                    h = yRun = 0;
                    e.scrollTopInterval = window.setInterval(function () {
                        e.el.scrollTop -= c;
                        yRun++;
                        if (yRun >= f) e.el.scrollTop = a.y,
                        clearInterval(e.scrollTopInterval)
                    },
                    10);
                    e.scrollLeftInterval = window.setInterval(function () {
                        e.el.scrollLeft -= d;
                        h++;
                        if (h >= g) e.el.scrollLeft = a.x,
                        clearInterval(e.scrollLeftInterval)
                    },
                    10)
                }
            },
            enable: function () { },
            disable: function () { },
            hideScrollbars: function () { },
            addPullToRefresh: function () { },
            _scrollToTop: function (a) {
                this._scrollTo({
                    x: 0,
                    y: 0
                },
                a)
            },
            _scrollToBottom: function (a) {
                this._scrollTo({
                    x: 0,
                    y: this.el.scrollHeight - this.el.offsetHeight
                },
                a)
            },
            scrollToBottom: function (a) {
                return this._scrollToBottom(a)
            },
            scrollToTop: function (a) {
                return this._scrollToTop(a)
            },
            init: function (a, c) {
                this.el = a;
                this.jqEl = b(this.el);
                this.defaultProperties();
                for (j in c) this[j] = c[j];
                var d = this,
                f = function () {
                    d.eventsActive && d.adjustScroll()
                };
                this.jqEl.bind("destroy",
                function () {
                    d.disable(!0);
                    var a = d.el.jqmScrollerId;
                    e[a] && delete e[a];
                    b.unbind(b.touchLayer, "orientationchange-reshape", f)
                });
                b.bind(b.touchLayer, "orientationchange-reshape", f)
            },
            needsFormsFix: function (a) {
                return this.useJsScroll && this.isEnabled() && this.el.style.display != "none" && b(a).closest(this.jqEl).size() > 0
            },
            handleEvent: function (a) {
                if (!this.scrollingLocked) switch (a.type) {
                    case "touchstart":
                        clearInterval(this.scrollTopInterval);
                        this.preventHideRefresh = !this.refreshRunning;
                        this.moved = !1;
                        this.onTouchStart(a);
                        break;
                    case "touchmove":
                        this.onTouchMove(a);
                        break;
                    case "touchend":
                        this.onTouchEnd(a);
                        break;
                    case "scroll":
                        this.onScroll(a)
                }
            },
            coreAddPullToRefresh: function (a) {
                if (a) this.refreshElement = a;
                this.refreshElement == null ? (a = document.getElementById(this.container.id + "_pulldown"), a = a != null ? jq(a) : jq("<div id='" + this.container.id + "_pulldown' class='jqscroll_refresh' style='border-radius:.6em;border: 1px solid #2A2A2A;background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0,#666666),color-stop(1,#222222));background:#222222;margin:0px;height:60px;position:relative;text-align:center;line-height:60px;color:white;width:100%;'>" + this.refreshContent + "</div>")) : a = jq(this.refreshElement);
                a = a.get();
                this.refreshContainer = jq('<div style="overflow:hidden;width:100%;height:0;margin:0;padding:0;padding-left:5px;padding-right:5px;display:none;"></div>');
                b(this.el).prepend(this.refreshContainer.append(a, "top"));
                this.refreshContainer = this.refreshContainer[0]
            },
            fireRefreshRelease: function (a) {
                if (this.refresh && a && (a = b.trigger(this, "refresh-release", [a]) !== !1, this.preventHideRefresh = !1, this.refreshRunning = !0, a)) {
                    var c = this;
                    if (this.refreshHangTimeout > 0) this.refreshCancelCB = setTimeout(function () {
                        c.hideRefresh()
                    },
                    this.refreshHangTimeout)
                }
            },
            setRefreshContent: function (a) {
                jq(this.container).find(".jqscroll_refresh").html(a)
            },
            lock: function () {
                if (!this.scrollingLocked) this.scrollingLocked = !0,
                (this.rememberEventsActive = this.eventsActive) || this.initEvents()
            },
            unlock: function () {
                if (this.scrollingLocked) this.scrollingLocked = !1,
                this.rememberEventsActive || this.removeEvents()
            },
            scrollToItem: function (a, c, d) {
                b.is$$(a) || (a = b(a));
                c == "bottom" ? (a = a.offset(), a = a.top - this.jqEl.offset().bottom + a.height, a += 4) : (a = a.offset().top - document.body.scrollTop, c = this.jqEl.offset().top, document.body.scrollTop < c && (a -= c), a -= 4);
                this.scrollBy({
                    y: a,
                    x: 0
                },
                d)
            },
            setPaddings: function (a, c) {
                var d = b(this.el),
                e = numOnly(d.css("paddingTop"));
                d.css("paddingTop", a + "px").css("paddingBottom", c + "px");
                this.scrollBy({
                    y: a - e,
                    x: 0
                })
            },
            divide: function (a, b) {
                return b != 0 ? a / b : 0
            },
            isEnabled: function () {
                return this.eventsActive
            },
            addInfinite: function () {
                this.infinite = !0
            },
            clearInfinite: function () {
                this.infiniteTriggered = !1;
                this.scrollSkip = !0
            }
        };
        i = function (a, c) {
            this.init(a, c);
            this.container = this.el.parentNode;
            this.container.jqmScrollerId = a.jqmScrollerId;
            this.jqEl = b(this.container);
            if (this.container.style.overflow != "hidden") this.container.style.overflow = "hidden";
            this.addPullToRefresh(null, !0);
            this.autoEnable && this.enable(!0);
            if (this.verticalScroll && this.verticalScroll == !0 && this.scrollBars == !0) {
                var e = d(5, 20);
                e.style.top = "0px";
                if (this.vScrollCSS) e.className = this.vScrollCSS;
                e.style.opacity = "0";
                this.container.appendChild(e);
                this.vscrollBar = e
            }
            if (this.horizontalScroll && this.horizontalScroll == !0 && this.scrollBars == !0) {
                e = d(20, 5);
                e.style.bottom = "0px";
                if (this.hScrollCSS) e.className = this.hScrollCSS;
                e.style.opacity = "0";
                this.container.appendChild(e);
                this.hscrollBar = e
            }
            this.horizontalScroll && (this.el.style["float"] = "left");
            this.el.hasScroller = !0
        };
        h = function (a, c) {
            this.init(a, c);
            var d = b(a);
            if (c.noParent !== !0) {
                var e = d.parent(),
                f = e.height();
                f += f.indexOf("%") == -1 ? "px" : "";
                d.css("height", f);
                d.parent().parent().append(d);
                e.remove()
            }
            this.container = this.el;
            d.css("-webkit-overflow-scrolling", "touch")
        };
        h.prototype = new m;
        i.prototype = new m;
        h.prototype.defaultProperties = function () {
            this.refreshContainer = null;
            this.dY = this.cY = 0;
            this.cancelPropagation = !1;
            this.loggedPcentX = this.loggedPcentY = 0;
            var a = this;
            this.adjustScrollOverflowProxy_ = function () {
                a.jqEl.css("overflow", "auto")
            }
        };
        h.prototype.enable = function (a) {
            if (!this.eventsActive) this.eventsActive = !0,
            this.el.style.overflow = "auto",
            a || this.adjustScroll(),
            (this.refresh || this.infinite && !jq.os.desktop) && this.el.addEventListener("touchstart", this, !1),
            this.el.addEventListener("scroll", this, !1)
        };
        h.prototype.disable = function (a) {
            if (this.eventsActive) {
                this.logPos(this.el.scrollLeft, this.el.scrollTop);
                if (!a) this.el.style.overflow = "hidden";
                this.el.removeEventListener("touchstart", this, !1);
                this.el.removeEventListener("touchmove", this, !1);
                this.el.removeEventListener("touchend", this, !1);
                this.el.removeEventListener("scroll", this, !1);
                this.eventsActive = !1
            }
        };
        h.prototype.addPullToRefresh = function (a, b) {
            this.el.removeEventListener("touchstart", this, !1);
            this.el.addEventListener("touchstart", this, !1);
            if (!b) this.refresh = !0;
            if (this.refresh && this.refresh == !0) this.coreAddPullToRefresh(a),
            this.refreshContainer.style.position = "absolute",
            this.refreshContainer.style.top = "-60px",
            this.refreshContainer.style.height = "60px",
            this.refreshContainer.style.display = "block"
        };
        h.prototype.onTouchStart = function (a) {
            this.refreshCancelCB && clearTimeout(this.refreshCancelCB);
            if (this.refresh || this.infinite) this.el.addEventListener("touchmove", this, !1),
            this.dY = a.touches[0].pageY,
            this.refresh && this.dY < 0 && this.showRefresh();
            b.trigger(this, "scrollstart", [this.el]);
            b.trigger(b.touchLayer, "scrollstart", [this.el])
        };
        h.prototype.onTouchMove = function (a) {
            var c = a.touches[0].pageY - this.dY;
            if (!this.moved) this.el.addEventListener("touchend", this, !1),
            this.moved = !0;
            if (this.refresh && this.el.scrollTop < 0) this.showRefresh();
            else if (this.refreshTriggered && this.refresh && this.el.scrollTop > this.refreshHeight) this.refreshTriggered = !1,
            this.refreshCancelCB && clearTimeout(this.refreshCancelCB),
            this.hideRefresh(!1),
            b.trigger(this, "refresh-cancel");
            this.cY = c;
            a.stopPropagation()
        };
        h.prototype.showRefresh = function () {
            if (!this.refreshTriggered) this.refreshTriggered = !0,
            b.trigger(this, "refresh-trigger")
        };
        h.prototype.onTouchEnd = function () {
            var a = this.el.scrollTop <= -this.refreshHeight;
            this.fireRefreshRelease(a, !0);
            if (a) this.refreshContainer.style.position = "relative",
            this.refreshContainer.style.top = "0px";
            this.dY = this.cY = 0;
            this.el.removeEventListener("touchmove", this, !1);
            this.el.removeEventListener("touchend", this, !1);
            this.infiniteEndCheck = !0;
            if (this.infinite && !this.infiniteTriggered && Math.abs(this.el.scrollTop) >= this.el.scrollHeight - this.el.clientHeight) this.infiniteTriggered = !0,
            b.trigger(this, "infinite-scroll"),
            this.infiniteEndCheck = !0;
            this.touchEndFired = !0;
            var c = this,
            d = {
                top: this.el.scrollTop,
                left: this.el.scrollLeft
            },
            e = 0;
            c.nativePolling = setInterval(function () {
                e++;
                if (e >= 200) clearInterval(c.nativePolling);
                else if (c.el.scrollTop != d.top || c.el.scrollLeft != d.left) clearInterval(c.nativePolling),
                b.trigger(b.touchLayer, "scrollend", [c.el]),
                b.trigger(c, "scrollend", [c.el])
            },
            20)
        };
        h.prototype.hideRefresh = function (a) {
            if (!this.preventHideRefresh) {
                var c = this,
                d = function (a) {
                    if (!a) c.el.style[b.feat.cssPrefix + "Transform"] = "none",
                    c.el.style[b.feat.cssPrefix + "TransitionProperty"] = "none",
                    c.el.scrollTop = 0,
                    c.logPos(c.el.scrollLeft, 0);
                    c.refreshContainer.style.top = "-60px";
                    c.refreshContainer.style.position = "absolute";
                    c.dY = c.cY = 0;
                    b.trigger(c, "refresh-finish")
                };
                a === !1 || !c.jqEl.css3Animate ? d() : c.jqEl.css3Animate({
                    y: c.el.scrollTop - c.refreshHeight + "px",
                    x: "0%",
                    time: "75ms",
                    complete: d
                });
                this.refreshTriggered = !1
            }
        };
        h.prototype.hideScrollbars = function () { };
        h.prototype.scrollTo = function (a, b) {
            this.logPos(a.x, a.y);
            a.x *= -1;
            a.y *= -1;
            return this._scrollTo(a, b)
        };
        h.prototype.scrollBy = function (a, b) {
            a.x += this.el.scrollLeft;
            a.y += this.el.scrollTop;
            this.logPos(this.el.scrollLeft, this.el.scrollTop);
            return this._scrollTo(a, b)
        };
        h.prototype.scrollToBottom = function (a) {
            this._scrollToBottom(a);
            this.logPos(this.el.scrollLeft, this.el.scrollTop)
        };
        h.prototype.onScroll = function () {
            if (this.infinite && this.touchEndFired) this.touchEndFired = !1;
            else if (this.scrollSkip) this.scrollSkip = !1;
            else {
                if (this.infinite && !this.infiniteTriggered && Math.abs(this.el.scrollTop) >= this.el.scrollHeight - this.el.clientHeight) this.infiniteTriggered = !0,
                b.trigger(this, "infinite-scroll"),
                this.infiniteEndCheck = !0;
                if (this.infinite && this.infiniteEndCheck && this.infiniteTriggered) this.infiniteEndCheck = !1,
                b.trigger(this, "infinite-scroll-end")
            }
        };
        h.prototype.logPos = function (a, b) {
            this.loggedPcentX = this.divide(a, this.el.scrollWidth);
            this.loggedPcentY = this.divide(b, this.el.scrollHeight);
            this.scrollLeft = a;
            this.scrollTop = b;
            if (isNaN(this.loggedPcentX)) this.loggedPcentX = 0;
            if (isNaN(this.loggedPcentY)) this.loggedPcentY = 0
        };
        h.prototype.adjustScroll = function () {
            this.adjustScrollOverflowProxy_();
            this.el.scrollLeft = this.loggedPcentX * this.el.scrollWidth;
            this.el.scrollTop = this.loggedPcentY * this.el.scrollHeight;
            this.logPos(this.el.scrollLeft, this.el.scrollTop)
        };
        i.prototype.defaultProperties = function () {
            this.boolScrollLock = !1;
            this.elementInfo = this.currentScrollingObject = null;
            this.verticalScroll = !0;
            this.horizontalScroll = !1;
            this.scrollBars = !0;
            this.hscrollBar = this.vscrollBar = null;
            this.vScrollCSS = this.hScrollCSS = "scrollBar";
            this.firstEventInfo = null;
            this.moved = !1;
            this.preventPullToRefresh = !0;
            this.doScrollInterval = null;
            this.refreshRate = 25;
            this.refreshSafeKeep = this.androidFormsMode = this.isScrolling = !1;
            this.lastScrollbar = "";
            this.scrollingFinishCB = this.container = this.finishScrollingObject = null;
            this.loggedPcentX = this.loggedPcentY = 0
        };
        i.prototype.enable = function (a) {
            if (!this.eventsActive) this.eventsActive = !0,
            a ? this.scrollerMoveCSS({
                x: 0,
                y: 0
            },
            0) : this.adjustScroll(),
            this.container.addEventListener("touchstart", this, !1),
            this.container.addEventListener("touchmove", this, !1),
            this.container.addEventListener("touchend", this, !1)
        };
        i.prototype.adjustScroll = function () {
            var a = this.getViewportSize();
            this.scrollerMoveCSS({
                x: Math.round(this.loggedPcentX * (this.el.clientWidth - a.w)),
                y: Math.round(this.loggedPcentY * (this.el.clientHeight - a.h))
            },
            0)
        };
        i.prototype.disable = function () {
            if (this.eventsActive) {
                var a = this.getCSSMatrix(this.el);
                this.logPos(numOnly(a.e) - numOnly(this.container.scrollLeft), numOnly(a.f) - numOnly(this.container.scrollTop));
                this.container.removeEventListener("touchstart", this, !1);
                this.container.removeEventListener("touchmove", this, !1);
                this.container.removeEventListener("touchend", this, !1);
                this.eventsActive = !1
            }
        };
        i.prototype.addPullToRefresh = function (a, b) {
            if (!b) this.refresh = !0;
            if (this.refresh && this.refresh == !0) this.coreAddPullToRefresh(a),
            this.el.style.overflow = "visible"
        };
        i.prototype.hideScrollbars = function () {
            if (this.hscrollBar) this.hscrollBar.style.opacity = 0,
            this.hscrollBar.style[b.feat.cssPrefix + "TransitionDuration"] = "0ms";
            if (this.vscrollBar) this.vscrollBar.style.opacity = 0,
            this.vscrollBar.style[b.feat.cssPrefix + "TransitionDuration"] = "0ms"
        };
        i.prototype.getViewportSize = function () {
            var a = window.getComputedStyle(this.container);
            isNaN(numOnly(a.paddingTop)) && alert(typeof a.paddingTop + "::" + a.paddingTop + ":");
            return {
                h: this.container.clientHeight > window.innerHeight ? window.innerHeight : this.container.clientHeight - numOnly(a.paddingTop) - numOnly(a.paddingBottom),
                w: this.container.clientWidth > window.innerWidth ? window.innerWidth : this.container.clientWidth - numOnly(a.paddingLeft) - numOnly(a.paddingRight)
            }
        };
        i.prototype.onTouchStart = function (a) {
            this.moved = !1;
            this.currentScrollingObject = null;
            if (this.container) {
                if (this.refreshCancelCB) clearTimeout(this.refreshCancelCB),
                this.refreshCancelCB = null;
                if (this.scrollingFinishCB) clearTimeout(this.scrollingFinishCB),
                this.scrollingFinishCB = null;
                if (!(a.touches.length != 1 || this.boolScrollLock)) {
                    if (a.touches[0].target && a.touches[0].target.type != void 0) {
                        var c = a.touches[0].target.tagName.toLowerCase();
                        if (c == "select" || c == "input" || c == "button") return
                    }
                    c = {
                        top: 0,
                        left: 0,
                        speedY: 0,
                        speedX: 0,
                        absSpeedY: 0,
                        absSpeedX: 0,
                        deltaY: 0,
                        deltaX: 0,
                        absDeltaY: 0,
                        absDeltaX: 0,
                        y: 0,
                        x: 0,
                        duration: 0
                    };
                    this.elementInfo = {};
                    var d = this.getViewportSize();
                    this.elementInfo.bottomMargin = d.h;
                    this.elementInfo.maxTop = this.el.clientHeight - this.elementInfo.bottomMargin;
                    if (this.elementInfo.maxTop < 0) this.elementInfo.maxTop = 0;
                    this.elementInfo.divHeight = this.el.clientHeight;
                    this.elementInfo.rightMargin = d.w;
                    this.elementInfo.maxLeft = this.el.clientWidth - this.elementInfo.rightMargin;
                    if (this.elementInfo.maxLeft < 0) this.elementInfo.maxLeft = 0;
                    this.elementInfo.divWidth = this.el.clientWidth;
                    this.elementInfo.hasVertScroll = this.verticalScroll || this.elementInfo.maxTop > 0;
                    this.elementInfo.hasHorScroll = this.elementInfo.maxLeft > 0;
                    this.elementInfo.requiresVScrollBar = this.vscrollBar && this.elementInfo.hasVertScroll;
                    this.elementInfo.requiresHScrollBar = this.hscrollBar && this.elementInfo.hasHorScroll;
                    this.saveEventInfo(a);
                    this.saveFirstEventInfo(a);
                    a = this.getCSSMatrix(this.el);
                    c.top = numOnly(a.f) - numOnly(this.container.scrollTop);
                    c.left = numOnly(a.e) - numOnly(this.container.scrollLeft);
                    this.container.scrollTop = this.container.scrollLeft = 0;
                    this.currentScrollingObject = this.el;
                    if (this.refresh && c.top == 0) this.refreshContainer.style.display = "block",
                    this.refreshHeight = this.refreshContainer.firstChild.clientHeight,
                    this.refreshContainer.firstChild.style.top = -this.refreshHeight + "px",
                    this.refreshContainer.style.overflow = "visible",
                    this.preventPullToRefresh = !1;
                    else if (c.top < 0 && (this.preventPullToRefresh = !0, this.refresh)) this.refreshContainer.style.overflow = "hidden";
                    c.x = c.left;
                    c.y = c.top;
                    if (this.setVScrollBar(c, 0, 0)) this.container.clientWidth > window.innerWidth ? this.vscrollBar.style.left = window.innerWidth - numOnly(this.vscrollBar.style.width) * 3 + "px" : this.vscrollBar.style.right = "0px",
                    this.vscrollBar.style[b.feat.cssPrefix + "Transition"] = "";
                    if (this.setHScrollBar(c, 0, 0)) this.container.clientHeight > window.innerHeight ? this.hscrollBar.style.top = window.innerHeight - numOnly(this.hscrollBar.style.height) + "px" : this.hscrollBar.style.bottom = numOnly(this.hscrollBar.style.height),
                    this.hscrollBar.style[b.feat.cssPrefix + "Transition"] = "";
                    this.lastScrollInfo = c;
                    this.hasMoved = !0;
                    this.scrollerMoveCSS(this.lastScrollInfo, 0);
                    b.trigger(this, "scrollstart")
                }
            }
        };
        i.prototype.getCSSMatrix = function (a) {
            if (this.androidFormsMode) {
                var c = parseInt(a.style.marginTop),
                a = parseInt(a.style.marginLeft);
                isNaN(c) && (c = 0);
                isNaN(a) && (a = 0);
                return {
                    f: c,
                    e: a
                }
            } else return b.getCssMatrix(a)
        };
        i.prototype.saveEventInfo = function (a) {
            this.lastEventInfo = {
                pageX: a.touches[0].pageX,
                pageY: a.touches[0].pageY,
                time: a.timeStamp
            }
        };
        i.prototype.saveFirstEventInfo = function (a) {
            this.firstEventInfo = {
                pageX: a.touches[0].pageX,
                pageY: a.touches[0].pageY,
                time: a.timeStamp
            }
        };
        i.prototype.setVScrollBar = function (a, c, b) {
            if (!this.elementInfo.requiresVScrollBar) return !1;
            var d = parseFloat(this.elementInfo.bottomMargin / this.elementInfo.divHeight) * this.elementInfo.bottomMargin + "px";
            if (d != this.vscrollBar.style.height) this.vscrollBar.style.height = d;
            a = this.elementInfo.bottomMargin - numOnly(this.vscrollBar.style.height) - (this.elementInfo.maxTop + a.y) / this.elementInfo.maxTop * (this.elementInfo.bottomMargin - numOnly(this.vscrollBar.style.height));
            if (a > this.elementInfo.bottomMargin) a = this.elementInfo.bottomMargin;
            a < 0 && (a = 0);
            this.scrollbarMoveCSS(this.vscrollBar, {
                x: 0,
                y: a
            },
            c, b);
            return !0
        };
        i.prototype.setHScrollBar = function (a, c, b) {
            if (!this.elementInfo.requiresHScrollBar) return !1;
            var d = parseFloat(this.elementInfo.rightMargin / this.elementInfo.divWidth) * this.elementInfo.rightMargin + "px";
            if (d != this.hscrollBar.style.width) this.hscrollBar.style.width = d;
            a = this.elementInfo.rightMargin - numOnly(this.hscrollBar.style.width) - (this.elementInfo.maxLeft + a.x) / this.elementInfo.maxLeft * (this.elementInfo.rightMargin - numOnly(this.hscrollBar.style.width));
            if (a > this.elementInfo.rightMargin) a = this.elementInfo.rightMargin;
            a < 0 && (a = 0);
            this.scrollbarMoveCSS(this.hscrollBar, {
                x: a,
                y: 0
            },
            c, b);
            return !0
        };
        i.prototype.onTouchMove = function (a) {
            if (this.currentScrollingObject != null) {
                var c = this.calculateMovement(a);
                this.calculateTarget(c);
                this.lastScrollInfo = c;
                if (!this.moved) {
                    if (this.elementInfo.requiresVScrollBar) this.vscrollBar.style.opacity = 1;
                    if (this.elementInfo.requiresHScrollBar) this.hscrollBar.style.opacity = 1
                }
                this.moved = !0;
                if (this.refresh && c.top == 0) this.refreshContainer.style.display = "block",
                this.refreshHeight = this.refreshContainer.firstChild.clientHeight,
                this.refreshContainer.firstChild.style.top = -this.refreshHeight + "px",
                this.refreshContainer.style.overflow = "visible",
                this.preventPullToRefresh = !1;
                else if (c.top < 0 && (this.preventPullToRefresh = !0, this.refresh)) this.refreshContainer.style.overflow = "hidden";
                this.saveEventInfo(a);
                this.doScroll()
            }
        };
        i.prototype.doScroll = function () {
            if (!this.isScrolling && this.lastScrollInfo.x != this.lastScrollInfo.left || this.lastScrollInfo.y != this.lastScrollInfo.top) {
                this.isScrolling = !0;
                if (this.onScrollStart) this.onScrollStart();
                var a = this.getCSSMatrix(this.el);
                this.lastScrollInfo.top = numOnly(a.f);
                this.lastScrollInfo.left = numOnly(a.e);
                this.recalculateDeltaY(this.lastScrollInfo);
                this.recalculateDeltaX(this.lastScrollInfo);
                this.checkYboundary(this.lastScrollInfo);
                this.elementInfo.hasHorScroll && this.checkXboundary(this.lastScrollInfo);
                var a = this.lastScrollInfo.y > 0 && this.lastScrollInfo.deltaY > 0,
                c = this.lastScrollInfo.y < -this.elementInfo.maxTop && this.lastScrollInfo.deltaY < 0;
                if (a || c) {
                    var d = (this.container.clientHeight - (a ? this.lastScrollInfo.y : -this.lastScrollInfo.y - this.elementInfo.maxTop)) / this.container.clientHeight;
                    d < 0.5 && (d = 0.5);
                    var e = 0;
                    a && this.lastScrollInfo.top > 0 || c && this.lastScrollInfo.top < -this.elementInfo.maxTop ? e = this.lastScrollInfo.top : c && (e = -this.elementInfo.maxTop);
                    c = this.lastScrollInfo.deltaY * d;
                    Math.abs(this.lastScrollInfo.deltaY * d) < 1 && (c = a ? 1 : -1);
                    this.lastScrollInfo.y = e + c
                }
                this.scrollerMoveCSS(this.lastScrollInfo, 0);
                this.setVScrollBar(this.lastScrollInfo, 0, 0);
                this.setHScrollBar(this.lastScrollInfo, 0, 0);
                if (this.refresh && !this.preventPullToRefresh) if (!this.refreshTriggered && this.lastScrollInfo.top > this.refreshHeight) this.refreshTriggered = !0,
                b.trigger(this, "refresh-trigger");
                else if (this.refreshTriggered && this.lastScrollInfo.top < this.refreshHeight) this.refreshTriggered = !1,
                b.trigger(this, "refresh-cancel");
                if (this.infinite && !this.infiniteTriggered && Math.abs(this.lastScrollInfo.top) >= this.el.clientHeight - this.container.clientHeight) this.infiniteTriggered = !0,
                b.trigger(this, "infinite-scroll")
            }
        };
        i.prototype.calculateMovement = function (a, c) {
            var b = {
                top: 0,
                left: 0,
                speedY: 0,
                speedX: 0,
                absSpeedY: 0,
                absSpeedX: 0,
                deltaY: 0,
                deltaX: 0,
                absDeltaY: 0,
                absDeltaX: 0,
                y: 0,
                x: 0,
                duration: 0
            },
            d = c ? this.firstEventInfo : this.lastEventInfo,
            e = c ? a.pageX : a.touches[0].pageX,
            f = c ? a.pageY : a.touches[0].pageY,
            g = c ? a.time : a.timeStamp;
            b.deltaY = this.elementInfo.hasVertScroll ? f - d.pageY : 0;
            b.deltaX = this.elementInfo.hasHorScroll ? e - d.pageX : 0;
            b.time = g;
            b.duration = g - d.time;
            return b
        };
        i.prototype.calculateTarget = function (a) {
            a.y = this.lastScrollInfo.y + a.deltaY;
            a.x = this.lastScrollInfo.x + a.deltaX
        };
        i.prototype.checkYboundary = function (a) {
            var c = this.container.clientHeight / 2,
            b = this.elementInfo.maxTop + c;
            if (a.y > c) a.y = c;
            else if (-a.y > b) a.y = -b;
            else return;
            this.recalculateDeltaY(a)
        };
        i.prototype.checkXboundary = function (a) {
            if (a.x > 0) a.x = 0;
            else if (-a.x > this.elementInfo.maxLeft) a.x = -this.elementInfo.maxLeft;
            else return;
            this.recalculateDeltaY(a)
        };
        i.prototype.recalculateDeltaY = function (a) {
            var c = Math.abs(a.deltaY);
            a.deltaY = a.y - a.top;
            newAbsDeltaY = Math.abs(a.deltaY);
            a.duration = a.duration * newAbsDeltaY / c
        };
        i.prototype.recalculateDeltaX = function (a) {
            var c = Math.abs(a.deltaX);
            a.deltaX = a.x - a.left;
            newAbsDeltaX = Math.abs(a.deltaX);
            a.duration = a.duration * newAbsDeltaX / c
        };
        i.prototype.hideRefresh = function () {
            var a = this;
            if (!this.preventHideRefresh) this.scrollerMoveCSS({
                x: 0,
                y: 0,
                complete: function () {
                    b.trigger(a, "refresh-finish")
                }
            },
            75),
            this.refreshTriggered = !1
        };
        i.prototype.setMomentum = function (a) {
            a.speedY = this.divide(a.deltaY, a.duration);
            a.speedX = this.divide(a.deltaX, a.duration);
            a.absSpeedY = Math.abs(a.speedY);
            a.absSpeedX = Math.abs(a.speedX);
            a.absDeltaY = Math.abs(a.deltaY);
            a.absDeltaX = Math.abs(a.deltaX);
            if (a.absDeltaY > 0) {
                if (a.deltaY = (a.deltaY < 0 ? -1 : 1) * a.absSpeedY * a.absSpeedY / 0.0024, a.absDeltaY = Math.abs(a.deltaY), a.duration = a.absSpeedY / 0.0012, a.speedY = a.deltaY / a.duration, a.absSpeedY = Math.abs(a.speedY), a.absSpeedY < 0.12 || a.absDeltaY < 5) a.deltaY = a.absDeltaY = a.duration = a.speedY = a.absSpeedY = 0
            } else if (a.absDeltaX) {
                if (a.deltaX = (a.deltaX < 0 ? -1 : 1) * a.absSpeedX * a.absSpeedX / 0.0024, a.absDeltaX = Math.abs(a.deltaX), a.duration = a.absSpeedX / 0.0012, a.speedX = a.deltaX / a.duration, a.absSpeedX = Math.abs(a.speedX), a.absSpeedX < 0.12 || a.absDeltaX < 5) a.deltaX = a.absDeltaX = a.duration = a.speedX = a.absSpeedX = 0
            } else a.duration = 0
        };
        i.prototype.onTouchEnd = function () {
            if (this.currentScrollingObject != null && this.moved) {
                this.finishScrollingObject = this.currentScrollingObject;
                this.currentScrollingObject = null;
                var a = this.calculateMovement(this.lastEventInfo, !0);
                this.androidFormsMode || this.setMomentum(a);
                this.calculateTarget(a);
                var c = this.getCSSMatrix(this.el);
                a.top = numOnly(c.f);
                a.left = numOnly(c.e);
                this.checkYboundary(a);
                this.elementInfo.hasHorScroll && this.checkXboundary(a);
                c = !this.preventPullToRefresh && (a.top > this.refreshHeight || a.y > this.refreshHeight);
                this.fireRefreshRelease(c, a.top > 0);
                if (this.refresh && c) a.y = this.refreshHeight,
                a.duration = 75;
                else if (a.y >= 0) {
                    if (a.y = 0, a.top >= 0) a.duration = 75
                } else if (-a.y > this.elementInfo.maxTop || this.elementInfo.maxTop == 0) if (a.y = -this.elementInfo.maxTop, -a.top > this.elementInfo.maxTop) a.duration = 75;
                if (this.androidFormsMode) a.duration = 0;
                this.scrollerMoveCSS(a, a.duration, "cubic-bezier(0.33,0.66,0.66,1)");
                this.setVScrollBar(a, a.duration, "cubic-bezier(0.33,0.66,0.66,1)");
                this.setHScrollBar(a, a.duration, "cubic-bezier(0.33,0.66,0.66,1)");
                this.setFinishCalback(a.duration);
                if (this.infinite && !this.infiniteTriggered && Math.abs(a.y) >= this.el.clientHeight - this.container.clientHeight) this.infiniteTriggered = !0,
                b.trigger(this, "infinite-scroll")
            }
        };
        i.prototype.setFinishCalback = function (a) {
            var c = this;
            this.scrollingFinishCB = setTimeout(function () {
                c.hideScrollbars();
                b.trigger(b.touchLayer, "scrollend", [c.el]);
                b.trigger(c, "scrollend", [c.el]);
                c.isScrolling = !1;
                c.elementInfo = null;
                c.infinite && b.trigger(c, "infinite-scroll-end")
            },
            a)
        };
        i.prototype.startFormsMode = function () {
            if (!this.blockFormsFix) {
                var a = this.getCSSMatrix(this.el);
                this.refreshSafeKeep = this.refresh;
                this.refresh = !1;
                this.androidFormsMode = !0;
                this.el.style[b.feat.cssPrefix + "Transform"] = "none";
                this.el.style[b.feat.cssPrefix + "Transition"] = "none";
                this.el.style[b.feat.cssPrefix + "Perspective"] = "none";
                this.scrollerMoveCSS({
                    x: numOnly(a.e),
                    y: numOnly(a.f)
                },
                0);
                this.container.style[b.feat.cssPrefix + "Perspective"] = "none";
                this.container.style[b.feat.cssPrefix + "BackfaceVisibility"] = "visible";
                this.vscrollBar && (this.vscrollBar.style[b.feat.cssPrefix + "Transform"] = "none", this.vscrollBar.style[b.feat.cssPrefix + "Transition"] = "none", this.vscrollBar.style[b.feat.cssPrefix + "Perspective"] = "none", this.vscrollBar.style[b.feat.cssPrefix + "BackfaceVisibility"] = "visible");
                this.hscrollBar && (this.hscrollBar.style[b.feat.cssPrefix + "Transform"] = "none", this.hscrollBar.style[b.feat.cssPrefix + "Transition"] = "none", this.hscrollBar.style[b.feat.cssPrefix + "Perspective"] = "none", this.hscrollBar.style[b.feat.cssPrefix + "BackfaceVisibility"] = "visible")
            }
        };
        i.prototype.stopFormsMode = function () {
            if (!this.blockFormsFix) {
                var a = this.getCSSMatrix(this.el);
                this.refresh = this.refreshSafeKeep;
                this.androidFormsMode = !1;
                this.el.style[b.feat.cssPrefix + "Perspective"] = 1E3;
                this.el.style.marginTop = 0;
                this.el.style.marginLeft = 0;
                this.el.style[b.feat.cssPrefix + "Transition"] = "0ms linear";
                this.scrollerMoveCSS({
                    x: numOnly(a.e),
                    y: numOnly(a.f)
                },
                0);
                this.container.style[b.feat.cssPrefix + "Perspective"] = 1E3;
                this.container.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden";
                this.vscrollBar && (this.vscrollBar.style[b.feat.cssPrefix + "Perspective"] = 1E3, this.vscrollBar.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden");
                this.hscrollBar && (this.hscrollBar.style[b.feat.cssPrefix + "Perspective"] = 1E3, this.hscrollBar.style[b.feat.cssPrefix + "BackfaceVisibility"] = "hidden")
            }
        };
        i.prototype.scrollerMoveCSS = function (a, d, e) {
            d || (d = 0);
            e || (e = "linear");
            d = numOnly(d);
            if (this.el && this.el.style) {
                if (this.eventsActive) this.androidFormsMode ? (this.el.style.marginTop = Math.round(a.y) + "px", this.el.style.marginLeft = Math.round(a.x) + "px") : (this.el.style[b.feat.cssPrefix + "Transform"] = "translate" + f + a.x + "px," + a.y + "px" + c, this.el.style[b.feat.cssPrefix + "TransitionDuration"] = d + "ms", this.el.style[b.feat.cssPrefix + "TransitionTimingFunction"] = e);
                this.logPos(a.x, a.y)
            }
        };
        i.prototype.logPos = function (a, c) {
            var b = this.elementInfo ? {
                h: this.elementInfo.bottomMargin,
                w: this.elementInfo.rightMargin
            } : this.getViewportSize();
            this.loggedPcentX = this.divide(a, this.el.clientWidth - b.w);
            this.loggedPcentY = this.divide(c, this.el.clientHeight - b.h);
            this.scrollTop = c;
            this.scrollLeft = a
        };
        i.prototype.scrollbarMoveCSS = function (a, d, e, g) {
            e || (e = 0);
            g || (g = "linear");
            if (a && a.style) this.androidFormsMode ? (a.style.marginTop = Math.round(d.y) + "px", a.style.marginLeft = Math.round(d.x) + "px") : (a.style[b.feat.cssPrefix + "Transform"] = "translate" + f + d.x + "px," + d.y + "px" + c, a.style[b.feat.cssPrefix + "TransitionDuration"] = e + "ms", a.style[b.feat.cssPrefix + "TransitionTimingFunction"] = g)
        };
        i.prototype.scrollTo = function (a, c) {
            c || (c = 0);
            this.scrollerMoveCSS(a, c)
        };
        i.prototype.scrollBy = function (a, c) {
            var b = this.getCSSMatrix(this.el),
            d = numOnly(b.f),
            b = numOnly(b.e);
            this.scrollTo({
                y: d - a.y,
                x: b - a.x
            },
            c)
        };
        i.prototype.scrollToBottom = function (a) {
            this.scrollTo({
                y: -1 * (this.el.clientHeight - this.container.clientHeight),
                x: 0
            },
            a)
        };
        i.prototype.scrollToTop = function (a) {
            this.scrollTo({
                x: 0,
                y: 0
            },
            a)
        };
        return function (a, c) {
            if (!k && b.touchLayer && b.isObject(b.touchLayer)) g();
            else if (!b.touchLayer || !b.isObject(b.touchLayer)) b.touchLayer = {};
            var d = typeof a == "string" || a instanceof String ? document.getElementById(a) : a;
            if (d) {
                if (jq.os.desktop) return new m(d, c);
                else if (c.useJsScroll) return new i(d, c);
                return new h(d, c)
            } else alert("Could not find element for scroller " + a)
        }
    } ()
})(jq); (function (b) {
    b.selectBox = {
        scroller: null,
        getOldSelects: function (h) {
            if (b.os.android && !b.os.androidICS) if (b.fn.scroller) {
                var g = h && document.getElementById(h) ? document.getElementById(h) : document;
                if (g) {
                    for (var e = g.getElementsByTagName("select"), k = this, m = 0; m < e.length; m++) e[m].hasSelectBoxFix ||
                    function (d) {
                        var f = document.createElement("div"),
                        c = window.getComputedStyle(d),
                        g = c.width == "intrinsic" ? "100%" : c.width,
                        g = parseInt(g) > 0 ? g : "100px",
                        h = parseInt(d.style.height) > 0 ? d.style.height : parseInt(c.height) ? c.height : "20px";
                        f.style.width = g;
                        f.style.height = h;
                        f.style.margin = c.margin;
                        f.style.position = c.position;
                        f.style.left = c.left;
                        f.style.top = c.top;
                        f.style.lineHeight = c.lineHeight;
                        f.style.zIndex = "1";
                        if (d.value) f.innerHTML = d.options[d.selectedIndex].text;
                        f.style.background = "url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABEAAAAeCAIAAABFWWJ4AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyBpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYwIDYxLjEzNDc3NywgMjAxMC8wMi8xMi0xNzozMjowMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNSBXaW5kb3dzIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOkM1NjQxRUQxNUFEODExRTA5OUE3QjE3NjI3MzczNDAzIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOkM1NjQxRUQyNUFEODExRTA5OUE3QjE3NjI3MzczNDAzIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzU2NDFFQ0Y1QUQ4MTFFMDk5QTdCMTc2MjczNzM0MDMiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzU2NDFFRDA1QUQ4MTFFMDk5QTdCMTc2MjczNzM0MDMiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz6YWbdCAAAAlklEQVR42mIsKChgIBGwAHFPTw/xGkpKSlggrG/fvhGjgYuLC0gyMZAOoPb8//9/0Or59+8f8XrICQN66SEnDOgcp3AgKiqKqej169dY9Hz69AnCuHv3rrKyMrIKoAhcVlBQELt/gIqwstHD4B8quH37NlAQSKKJEwg3iLbBED8kpeshoGcwh5uuri5peoBFMEluAwgwAK+5aXfuRb4gAAAAAElFTkSuQmCC') right top no-repeat";
                        f.style.backgroundColor = "white";
                        f.style.lineHeight = h;
                        f.style.backgroundSize = "contain";
                        f.className = "jqmobiSelect_fakeInput " + d.className;
                        f.id = d.id + "_jqmobiSelect";
                        f.style.border = "1px solid gray";
                        f.style.color = "black";
                        f.linkId = d.id;
                        f.onclick = function () {
                            k.initDropDown(this.linkId)
                        };
                        b(f).insertBefore(b(d));
                        d.style.display = "none";
                        d.style.webkitAppearance = "none";
                        for (c = 0; c < d.options.length; c++) {
                            if (d.options[c].selected) f.value = d.options[c].text;
                            d.options[c].watch("selected",
                            function (c, a, b) {
                                if (b == !0) d.getAttribute("multiple") || k.updateMaskValue(this.parentNode.id, this.text, this.value),
                                this.parentNode.value = this.value;
                                return b
                            })
                        }
                        d.watch("selectedIndex",
                        function (c, a, b) {
                            if (this.options[b]) d.getAttribute("multiple") || k.updateMaskValue(this.id, this.options[b].text, this.options[b].value),
                            this.value = this.options[b].value;
                            return b
                        });
                        imageMask = f = null;
                        e[m].hasSelectBoxFix = !0
                    } (e[m]);
                    k.createHtml()
                } else alert("Could not find container element for jq.web.selectBox " + h)
            } else alert("This library requires jq.web.Scroller")
        },
        updateDropdown: function (b) {
            if (b = document.getElementById(b)) {
                for (var g = 0; g < b.options.length; g++) {
                    if (b.options[g].selected) fakeInput.value = b.options[g].text;
                    b.options[g].watch("selected",
                    function (b, g, h) {
                        if (h == !0) that.updateMaskValue(this.parentNode.id, this.text, this.value),
                        this.parentNode.value = this.value;
                        return h
                    })
                }
                b = null
            }
        },
        initDropDown: function (b) {
            var g = this,
            e = document.getElementById(b);
            if (!e.disabled && e && e.options && e.options.length != 0) {
                var k = "",
                k = e.attributes.title || e.name;
                if (typeof k === "object") k = k.value;
                document.getElementById("jqmobiSelectBoxScroll").innerHTML = "";
                document.getElementById("jqmobiSelectBoxHeaderTitle").innerHTML = k.length > 0 ? k : b;
                for (k = 0; k < e.options.length; k++) {
                    e.options[k].watch("selected",
                    function (a, c, b) {
                        if (b == !0) g.updateMaskValue(this.parentNode.id, this.text, this.value),
                        this.parentNode.value = this.value;
                        return b
                    });
                    var m = e.options[k].selected ? !0 : !1,
                    d = document.createElement("div"),
                    f = document.createElement("a"),
                    c = document.createElement("span"),
                    i = document.createElement("button");
                    d.className = "jqmobiSelectRow";
                    d.style.cssText = "line-height:40px;font-size:14px;padding-left:10px;height:40px;width:100%;position:relative;width:100%;border-bottom:1px solid black;background:white;";
                    d.tmpValue = k;
                    d.onclick = function () {
                        g.setDropDownValue(b, this.tmpValue, this)
                    };
                    f.style.cssText = "text-decoration:none;color:black;";
                    f.innerHTML = e.options[k].text;
                    f.className = "jqmobiSelectRowText";
                    c.style.cssText = "float:right;margin-right:20px;margin-top:-2px";
                    m ? (i.style.cssText = "background: #000;padding: 0px 0px;border-radius:15px;border:3px solid black;", i.className = "jqmobiSelectRowButtonFound") : (i.style.cssText = "background: #ffffff;padding: 0px 0px;border-radius:15px;border:3px solid black;", i.className = "jqmobiSelectRowButton");
                    i.style.width = "20px";
                    i.style.height = "20px";
                    i.checked = m;
                    c.appendChild(i);
                    d.appendChild(f);
                    d.appendChild(c);
                    document.getElementById("jqmobiSelectBoxScroll").appendChild(d);
                    f = i = c = null
                }
                try {
                    document.getElementById("jqmobiSelectModal").style.display = "block"
                } catch (l) {
                    console.log("Error showing div " + l)
                }
                try {
                    if (d) {
                        var p = numOnly(d.style.height),
                        a = numOnly(document.getElementById("jqmobiSelectBoxHeader").style.height);
                        this.scroller.scrollTo({
                            x: 0,
                            y: 0 * p + a >= numOnly(document.getElementById("jqmobiSelectBoxFix").clientHeight) - a ? 0 * -p + a : 0
                        })
                    }
                } catch (o) {
                    console.log("error init dropdown" + o)
                }
                e = d = null
            }
        },
        updateMaskValue: function (b, g, e) {
            var k = document.getElementById(b + "_jqmobiSelect"),
            b = document.getElementById(b);
            if (k) k.innerHTML = g;
            if (typeof b.onchange == "function") b.onchange(e)
        },
        setDropDownValue: function (h, g, e) {
            if (h = document.getElementById(h)) h.getAttribute("multiple") ? (g = b(h).find("option:nth-child(" + (g + 1) + ")").get(0), g.selected ? (g.selected = !1, b(e).find("button").css("background", "#fff")) : (g.selected = !0, b(e).find("button").css("background", "#000"))) : (h.selectedIndex = g, b(h).find("option").forEach(function (b) {
                b.selected = !1
            }), b(h).find("option:nth-child(" + (g + 1) + ")").get(0).selected = !0, this.scroller.scrollTo({
                x: 0,
                y: 0
            }), this.hideDropDown()),
            b(h).trigger("change"),
            h = null
        },
        hideDropDown: function () {
            document.getElementById("jqmobiSelectModal").style.display = "none";
            document.getElementById("jqmobiSelectBoxScroll").innerHTML = ""
        },
        createHtml: function () {
            var h = this;
            if (!document.getElementById("jqmobiSelectBoxContainer")) {
                var g = document.createElement("div");
                g.style.cssText = "position:absolute;top:0px;bottom:0px;left:0px;right:0px;background:rgba(0,0,0,.7);z-index:200000;display:none;";
                g.id = "jqmobiSelectModal";
                var e = document.createElement("div");
                e.id = "jqmobiSelectBoxContainer";
                e.style.cssText = "position:absolute;top:8%;bottom:10%;display:block;width:90%;margin:auto;margin-left:5%;height:90%px;background:white;color:black;border:1px solid black;border-radius:6px;";
                e.innerHTML = '<div id="jqmobiSelectBoxHeader" style="display:block;font-family:\'Eurostile-Bold\', Eurostile, Helvetica, Arial, sans-serif;color:#fff;font-weight:bold;font-size:18px;line-height:34px;height:34px; text-transform:uppercase; text-align:left; text-shadow:rgba(0,0,0,.9) 0px -1px 1px; padding: 0px 8px 0px 8px; border-top-left-radius:5px; border-top-right-radius:5px; -webkit-border-top-left-radius:5px; -webkit-border-top-right-radius:5px; background:#39424b; margin:1px;"><div style="float:left;" id="jqmobiSelectBoxHeaderTitle"></div><div style="float:right;width:60px;margin-top:-5px"><div id="jqmobiSelectClose" class="button" style="width:60px;height:32px;line-height:32px;">Close</div></div></div><div id="jqmobiSelectBoxFix" style="position:relative;height:90%;background:white;overflow:hidden;width:100%;"><div id="jqmobiSelectBoxScroll"></div></div>';
                h = this;
                g.appendChild(e);
                b(document).ready(function () {
                    jq("#jQUi") ? jq("#jQUi").append(g) : document.body.appendChild(g);
                    b("#jqmobiSelectClose").get().onclick = function () {
                        h.hideDropDown()
                    };
                    var k = b("<style>.jqselectscrollBarV{opacity:1 !important;}</style>").get();
                    document.body.appendChild(k);
                    try {
                        h.scroller = b("#jqmobiSelectBoxScroll").scroller({
                            scroller: !1,
                            verticalScroll: !0,
                            vScrollCSS: "jqselectscrollBarV"
                        })
                    } catch (m) {
                        console.log("Error creating select html " + m)
                    }
                    k = e = g = null
                })
            }
        }
    };
    if (!HTMLElement.prototype.watch) HTMLElement.prototype.watch = function (b, g) {
        var e = this[b],
        k = e,
        m = function () {
            return k
        },
        d = function (d) {
            e = k;
            return k = g.call(this, b, e, d)
        };
        delete this[b] && (HTMLElement.defineProperty ? HTMLElement.defineProperty(this, b, {
            get: m,
            set: d,
            enumerable: !1,
            configurable: !0
        }) : HTMLElement.prototype.__defineGetter__ && HTMLElement.prototype.__defineSetter__ && (HTMLElement.prototype.__defineGetter__.call(this, b, m), HTMLElement.prototype.__defineSetter__.call(this, b, d)))
    };
    if (!HTMLElement.prototype.unwatch) HTMLElement.prototype.unwatch = function (b) {
        var g = this[b];
        delete this[b];
        this[b] = g
    }
})(jq); (function (b) {
    b.template = function (b, e) {
        return h(b, e)
    };
    b.tmpl = function (g, e) {
        return b(h(g, e))
    };
    var h = function (b, e) {
        e || (e = {});
        return tmpl(b, e)
    }; (function () {
        var b = {};
        this.tmpl = function k(h, d) {
            var f = !/\W/.test(h) ? b[h] = b[h] || k(document.getElementById(h).innerHTML) : new Function("obj", "var p=[],print=function(){p.push.apply(p,arguments);};with(obj){p.push('" + h.replace(/[\r\t\n]/g, " ").replace(/'(?=[^%]*%>)/g, "\t").split("'").join("\\'").split("\t").join("'").replace(/<%=(.+?)%>/g, "',$$1,'").split("<%").join("');").split("%>").join("p.push('") + "');}return p.join('');");
            return d ? f(d) : f
        }
    })()
})(jq); (function (b) {
    var h = function () { };
    b.fn.fadeOut = function (b, e, k) {
        if (this.length != 0) {
            b || (b = 0);
            var m = this,
            d = h;
            e || (e = h);
            k || (k = 0, d = function () {
                this.hide()
            });
            this.css3Animate({
                opacity: k,
                time: b,
                callback: function () {
                    e.apply(m);
                    d.apply(m)
                }
            });
            return this
        }
    };
    b.fn.fadeIn = function (b, e) {
        b || (b = "300ms");
        this.show();
        this.css("opacity", ".1");
        var k = this;
        window.setTimeout(function () {
            k.fadeOut(b, e, 10)
        },
        1);
        return this
    };
    b.fn.slideToggle = function (g, e, k) {
        for (var h = {
            time: g ? g : "500ms",
            callback: e ? e : null,
            easing: k ? k : "linear"
        },
        g = 0; g < this.length; g++) {
            var k = this.css("display", null, this[g]),
            d = !1,
            f = b(this[g]);
            k == "none" && (f.show(), d = !0);
            var c = this.css("height", null, this[g]);
            d ? (f.css("height", "0px"), h.height = c) : (h.height = "0px", e = function () {
                f.hide();
                f.css3Animate({
                    height: c,
                    time: "0ms"
                })
            });
            e && (h.callback = e);
            window.setTimeout(function () {
                f.css3Animate(h)
            },
            1)
        }
        return this
    }
})(jq); (function (b) {
    b.fn.actionsheet = function (b) {
        for (var e, k = 0; k < this.length; k++) e = new h(this[k], b);
        return this.length == 1 ? e : this
    };
    var h = function () {
        var g = function (e, h) {
            if (this.el = typeof e == "string" || e instanceof String ? document.getElementById(e) : e) {
                if (this instanceof g) {
                    if (typeof h == "object") for (j in h) this[j] = h[j]
                } else return new g(e, h);
                try {
                    var m = this,
                    d;
                    if (typeof h == "string") d = b('<div id="jq_actionsheet"><div style="width:100%">' + h + "<a href='javascript:;' class='cancel'>Cancel</a></div></div>");
                    else if (typeof h == "object") {
                        d = b('<div id="jq_actionsheet"><div style="width:100%"></div></div>');
                        var f = b(d.children().get());
                        h.push({
                            text: "Cancel",
                            cssClasses: "cancel"
                        });
                        for (var c = 0; c < h.length; c++) {
                            var i = b('<a href="javascript:;" >' + (h[c].text || "TEXT NOT ENTERED") + "</a>");
                            i[0].onclick = h[c].handler ||
                            function () { };
                            h[c].cssClasses && h[c].cssClasses.length > 0 && i.addClass(h[c].cssClasses);
                            f.append(i)
                        }
                    }
                    b(e).find("#jq_actionsheet").remove();
                    b(e).find("#jq_action_mask").remove();
                    actionsheetEl = b(e).append(d);
                    d.get().style[b.feat.cssPrefix + "Transition"] = "all 0ms";
                    d.css(b.feat.cssPrefix + "Transform", "translate" + b.feat.cssTransformStart + "0,0" + b.feat.cssTransformEnd);
                    d.css("top", window.innerHeight + "px");
                    this.el.style.overflow = "hidden";
                    d.on("click", "a",
                    function () {
                        m.hideSheet()
                    });
                    this.activeSheet = d;
                    b(e).append('<div id="jq_action_mask" style="position:absolute;top:0px;left:0px;right:0px;bottom:0px;z-index:9998;background:rgba(0,0,0,.4)"/>');
                    setTimeout(function () {
                        d.get().style[b.feat.cssPrefix + "Transition"] = "all 300ms";
                        d.css(b.feat.cssPrefix + "Transform", "translate" + b.feat.cssTransformStart + "0," + -d.height() + "px" + b.feat.cssTransformEnd)
                    },
                    10)
                } catch (l) {
                    alert("error adding actionsheet" + l)
                }
            } else alert("Could not find element for actionsheet " + e)
        };
        g.prototype = {
            activeSheet: null,
            hideSheet: function () {
                var e = this;
                this.activeSheet.off("click", "a",
                function () {
                    e.hideSheet()
                });
                b(this.el).find("#jq_action_mask").remove();
                this.activeSheet.get().style[b.feat.cssPrefix + "Transition"] = "all 0ms";
                var g = this.activeSheet,
                h = this.el;
                setTimeout(function () {
                    g.get().style[b.feat.cssPrefix + "Transition"] = "all 300ms";
                    g.css(b.feat.cssPrefix + "Transform", "translate" + b.feat.cssTransformStart + "0,0px" + b.feat.cssTransformEnd);
                    setTimeout(function () {
                        g.remove();
                        g = null;
                        h.style.overflow = "none"
                    },
                    500)
                },
                10)
            }
        };
        return g
    } ()
})(jq);