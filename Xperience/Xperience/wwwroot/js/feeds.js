(function () {
    var posts = {
        init: function () {
            this.cacheDOM();
            this.loadData(1);
            this.bindFunctions();
        },
        cacheDOM: function () {
            this.pageNumber = 1;
            this.$post = $(".posts");
        },
        bindFunctions: function () {
            $(window).scroll(function () {
                
                if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                    this.pageNumber += 1;
                    this.loadData(this.pageNumber)
                }               
            }.bind(this));
        },
        loadData: function (currentPage) {
            $.ajax({
                url: '/api/Posts?pageNumber=' + currentPage +'&nOfPosts=1',
                type: 'POST',
                success: function (data) {
                    this.previewData(data);
                }.bind(this)
            });
        },
        previewData(data) {
            $.each(data, function (i, item) {
                var body = "";
                body += "<div class='row'>";
                body += "<div class = 'col-md-4'></div>";
                body += "<div class='col-md-4 post'>";
                body += "<p>" + item.postDate + "<p>";
                body += "</div></div>";
                this.$post.append(body);
            }.bind(this));
        }
    }
    posts.init();
    
})();