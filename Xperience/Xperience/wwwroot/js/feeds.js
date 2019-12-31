(function () {
    var posts = {
        init: function () {
            this.cacheDOM();
            this.bindFunctions();
            this.loadData(1);
        },
        cacheDOM: function () {
            this.pageNumber = 1;
            this.$post = $(".posts");
            this.$postDetails = $("#post_details");
            this.$caption = $("#caption");
            this.$site = $("#site");
            this.$hashtag = $("#hashtag");
            this.$addPost = $("#add_post");
        },
        bindFunctions: function () {
            $(window).scroll(this.checkScroll.bind(this));
            this.$addPost.click(this.createPost.bind(this));
        },
        checkScroll: function () {
            if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                this.pageNumber++;
                this.loadData(this.pageNumber);
            }
        },
        loadData: function (currentPage) {
            $.ajax({
                url: '/api/Posts/' + currentPage + ',10',
                type: 'POST',
                success: function (data) {
                    this.previewData(data);
                }.bind(this)
            });
        },
        previewData: function (data) {
            $.each(data, function (i, item) {
                var body = "";
                body += "<div class='row' style='margin-bottom:30px'>";
                body += "<div class = 'col-md-2'></div>";
                body += "<div class='col-md-8 post'>";
                body += "<p>" + item.postDate + "<p>";
                body += "</div></div>";
                this.$post.append(body);
            }.bind(this));
        },
        createPost: function () {
            var post = {
                "PostDetails": this.$postDetails.val(),
                "Caption": this.$caption.val(),
                "Site": this.$site.val(),
                "Hashtag": this.$hashtag.val()
            }
            this.insertData(JSON.stringify(post));
        },
        insertData: function (data) {
            console.log(data);
            $.ajax({
                url: '/api/Posts?',
                contentType: 'application/json',
                data: data,
                type: 'POST',
                success: function (returnData) {
                    this.$post.empty();
                    this.loadData(1);
                }.bind(this)
            });
        }
    }
    posts.init();

})();