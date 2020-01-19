(function () {
    var posts = {
        init: function () {
            this.cacheDOM();
            this.bindFunctions();
            this.loadData(1, 10, 1, 1);
        },
        cacheDOM: function () {
            this.pageNumber = 1;
            this.$post = $(".posts");
            this.$postDetails = $("#post_details");
            this.$caption = $("#caption");
            this.$site = $("#site");
            this.$hashtag = $("#hashtag");
            this.$addPost = $("#add_post");
            this.$imgSrc = "";
        },
        bindFunctions: function () {
            $(window).scroll(this.checkScroll.bind(this));
            this.$addPost.click(this.createPost.bind(this));
        },
        checkScroll: function () {
            if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                this.pageNumber++;
                this.loadData(this.pageNumber, 10, 1, 0);
            }
        },
        loadData: function (currentPage, nOfPosts, method, isInitial) {
            $.ajax({
                url: '/api/Posts/' + currentPage + ',' + nOfPosts,
                type: 'POST',
                success: function (data) {
                    if (method == 0) {
                        this.$post.prepend(this.previewData(data));
                    } else {
                        this.$post.append(this.previewData(data));
                    }
                    if (isInitial == 1) {
                        comments.init();
                    }
                    comments.bindFunctions();
                }.bind(this),
            });
        },
        previewData: function (data) {
            body = "";
            $.each(data, function (i, item) {
                body += "<div class='row' style='margin-bottom:30px'>";
                body += "<div class = 'col-md-3'></div>";
                body += "<div class='col-md-6 post'>";
                body += "<h3>" + item.name + "<h3> <br/>";
                body += "<img src='/Images/PostPictures/" + item.postDetails + "' class='postImage'>";
                body += "<p>" + item.caption + "<p>";
                body += "<p>#" + item.hashtag + "<p>";
                body += "<button class='comments' id='" + item.id + "'> Comments </button>";
                body += "</div></div>";
            }.bind(this));
            return body;
        },
        createPost: function () {
            var data = new FormData();
            var img = this.$postDetails[0].files[0];
            data.append("postDetails", img);
            data.append("Caption", this.$caption.val());
            data.append("Site", this.$site.val());
            data.append("Hashtag", this.$hashtag.val());
            this.insertData(data);
        },
        insertData: function (data) {
            console.log(data);
            $.ajax({
                url: '/api/Posts?',
                contentType: 'application/json',
                data: data,
                enctype: "multipart/form-data",
                processData: false,
                contentType: false,
                type: 'POST',
                success: function (returnData) {
                    this.reloadData();
                }.bind(this)
            });
        },
        reloadData: function () {
            this.$postDetails.val('');
            this.$caption.val('');
            this.$hashtag.val('');
            this.$site.val('');
            this.loadData(1, 1, 0, 0);
        }
    }
    var comments = {
        init: function () {
            this.cacheDOM();
        },
        cacheDOM: function () {
            this.$Comments = $(".comments"); 
        },
        bindFunctions: function () {
        },
        getComments: function () {
            alert('yay');
        }

    }
    posts.init();

})();