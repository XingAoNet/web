(function ($) {
    $.fn.sTurntable = function (option, settings) {
        if (typeof option === 'object') {
            settings = option;
        }
        else if (typeof option == 'string') {
            var values = [];

            var elements = this.each(function () {
                var data = $(this).data('_Turntable');

                if (data) {
                    if (option === 'reset') { data.reset(); }
                    else if (option === 'clear') { data.clear(); }
                    else if (option === 'enabled') { data.enabled = settings === true; }
                    else if ($.fn.sTurntable.defaultSettings[option] !== undefined) {
                        if (settings !== undefined) { data.settings[option] = settings; }
                        else { values.push(data.settings[option]); }
                    }
                }
            });

            if (values.length === 1) { return values[0]; }
            if (values.length > 0) { return values; }
            else { return elements; }
        }

        settings = $.extend({}, $.fn.sTurntable.defaultSettings, settings || {});

        return this.each(function () {
            var elem = $(this);
            var $settings = jQuery.extend(true, {}, settings);
            var test = document.createElement('canvas');
            if (!test.getContext) {
                elem.html("Browser does not support HTML5 canvas, please upgrade to a more modern browser.");
                return false;
            }

            var sp = new Turntable($settings, elem);
            elem.append(sp.generate());
            sp.pixels = sp.canvas.width * sp.canvas.height;
            elem.data('_Turntable', sp);
            sp.init();
        });
    };

    $.fn.sTurntable.defaultSettings =
	{
	    width: 300,
	    height: 300,
	    image: '/images/zz.png',
	    size: 10,
	    Background: '/images/gq.png',
	    DataColos: ["#B8D430", "#CC0071", "#F80120", "#F35B20", "#FB9A00", "#FFCC00", "#FEF200", "#3AB745", "#029990", "#3501CB", "#2E2C75", "#673A7E"], //奖品背景色
	    Restaraunts: [],  //奖品数据
	    outsideRadius: 300, //外圆半径
	    insideRadius: 60, //内圆半径
	    textRadius: 200,  //文字半径
	    startAngle: 0, //初始角度
	    arc: 2 * Math.PI / 1, //角度
	    spinTimeout: null,
	    spinArcStart: 10,
	    spinTime: 0,
	    spinTimeTotal: 0,
	    font: "20px 黑体",
	    CallBack: null,
	    maxRound: 1,
	    CurRound: 0,
	    checkCall: null
	};


    function Turntable(settings, elem) {
        this.sp = null;
        this.settings = settings;
        this.$elem = elem;
        this.enabled = true;
        this.scratch = false;
        this.canvas = null;
        this.ctx = null;
        return this;
    }

    Turntable.prototype =
	{
	    generate: function () {
	        var $this = this;
	        this.canvas = document.createElement('canvas');
	        this.ctx = this.canvas.getContext('2d');

	        this.sp =
			$("<div></div>")
			.css({ position: 'relative' })
			.append(
				$(this.canvas)
				.attr('width', this.settings.width + 'px')
				.attr('height', this.settings.height + 'px')
			).append($("<div></div>").css({ "position": 'absolute', "overflow": "hidden", "width": "35px", "height": "140", "backgroundImage": "url(" + this.settings.image + ")", "top": (this.settings.height / 2) - 110 + "px", "left": (this.settings.width / 2) - 17 }).click(function (ex) {
			    var check = true;
			    if ($this.settings.checkCall)
			        check = $this.settings.checkCall()
			    if (check) {
			        if ($this.settings.spinTime == 0) {
			            if ($this.settings.CurRound < $this.settings.maxRound) {
			                $this.spin();
			                $this.settings.CurRound++;
			            }
			            else {
			                alert("今日抽奖次数已用完！");
			            }
			        }

			    }

			}));
	        return this.sp;
	    },


	    init: function () {
	        this.settings.outsideRadius = this.settings.width / 2 - 15;
	        this.settings.insideRadius = 30;
	        this.settings.textRadius = this.settings.outsideRadius - 20;
	        this.settings.arc = 2 * Math.PI / this.settings.Restaraunts.length;
	        this.settings.startAngle = 0;
	        this.settings.spinTime == 0
	        this.settings.spinArcStart = 10;
	        this.settings.spinTimeTotal = 0;

	        switch (this.settings.Restaraunts.length) {
	            case 9:
	                this.settings.font = "20px 黑体";
	                break;
	                case10:
	                this.settings.font = "18px 黑体";
	                break;
	            case 11:
	                this.settings.font = "16px 黑体";
	                break;
	            case 12:
	                this.settings.font = "14px 黑体";
	                break;
	        }

	        this.sp.css('width', this.settings.width);
	        this.sp.css('height', this.settings.height);
	        if (this.settings.Background)
	            this.sp.css('backgroundImage', "url(" + this.settings.Background + ")");
	        this.canvas.width = this.settings.width;
	        this.canvas.height = this.settings.height;
	        this.drawRouletteWheel();

	    },
	    drawRouletteWheel: function () {
	        var Center_x = this.settings.width / 2;
	        var Center_y = this.settings.height / 2;
	        this.ctx.strokeStyle = "white";
	        this.ctx.lineWidth = 0;
	        this.ctx.font = this.settings.font;
	        for (var i = 0; i < this.settings.Restaraunts.length; i++) {

	            var angle = this.settings.startAngle + i * this.settings.arc;
	            this.ctx.fillStyle = this.settings.DataColos[i];
	            this.ctx.beginPath();
	            this.ctx.arc(Center_x, Center_y, this.settings.outsideRadius, angle, angle + this.settings.arc, false);
	            this.ctx.arc(Center_x, Center_y, this.settings.insideRadius, angle + this.settings.arc, angle, true);
	            this.ctx.stroke();
	            this.ctx.fill();
	            this.ctx.save();
	            this.ctx.shadowOffsetX = -1;
	            this.ctx.shadowOffsetY = -1;
	            this.ctx.shadowBlur = 0;
	            this.ctx.shadowColor = "rgb(255,255,255)";
	            this.ctx.fillStyle = "white"; //中间文字颜色


	            this.ctx.translate(Center_x + Math.cos(angle + this.settings.arc / 2) * this.settings.textRadius, Center_y + Math.sin(angle + this.settings.arc / 2) * this.settings.textRadius);
	            this.ctx.rotate(angle + this.settings.arc / 2 + Math.PI / 2);

	            var text = this.settings.Restaraunts[i];
	            var nt = "";
	            var j = 0;
	            do {
	                nt = text.substring(0, 4);
	                text = text.substring(4);
	                this.ctx.fillText(nt, -this.ctx.measureText(nt).width / 2, j * 20);
	                j++;
	            }
	            while (text.length > 0);
	            this.ctx.restore();
	        }
	    },
	    spin: function () //开始摇奖
	    {
	        this.settings.spinAngleStart = Math.random() * 10 + 10;
	        this.settings.spinTime = 0;
	        this.settings.spinTimeTotal = Math.random() * 3 + 8 * 1000; //旋转时间
	        this.rotateWheel();

	    },

	    rotateWheel: function ()//转动转盘
	    {
	        this.settings.spinTime += 30;
	        if (this.settings.spinTime >= this.settings.spinTimeTotal) {
	            this.stopRotateWheel();
	            return;
	        }
	        var spinAngle = this.settings.spinAngleStart - this.easeOut(this.settings.spinTime, 0, this.settings.spinAngleStart, this.settings.spinTimeTotal);
	        this.settings.startAngle += (spinAngle * Math.PI / 180);
	        this.drawRouletteWheel();
	        var _this = this;
	        this.settings.spinTimeout = setTimeout(function (ex) { _this.rotateWheel(); }, 30);
	    },
	    stopRotateWheel: function ()//转盘停止转动
	    {

	        clearTimeout(this.settings.spinTimeout);
	        var degrees = this.settings.startAngle * 180 / Math.PI + 90;
	        var arcd = this.settings.arc * 180 / Math.PI;
	        var index = Math.floor((360 - degrees % 360) / arcd);
	        if (this.settings.CallBack != null)
	            this.settings.CallBack(this.settings.Restaraunts[index]);
	        this.settings.spinTime = 0;
	    },
	    easeOut: function (t, b, c, d) {
	        var ts = (t /= d) * t;
	        var tc = ts * t;
	        return b + c * (tc + -3 * ts + 3 * t);
	    }

	}
})(jQuery);