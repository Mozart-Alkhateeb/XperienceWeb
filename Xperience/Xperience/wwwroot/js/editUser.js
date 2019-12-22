(function () {
    var inputElements = {
        init: function () {
            this.cacheDOM();
            this.initialize();
            this.bindFunctions();
        },
        initialize: function () {
            this.$saveButton.hide();
            this.$infoForm.hide();
        },
        cacheDOM: function () {
            this.$saveButton = $("#saveButton");
            this.$editButton = $(".editButton");
            this.$Elements = $(".inputElement");
            this.$input = $(".langs, .nations");
            this.$selectInputs = $(".selectInput");
            this.$gender = $("#gender");
            this.$isConnector = $("#isConnector");
            this.$infoForm = $("#info");
        },
        bindFunctions: function () {
            this.$editButton.on('click', this.makeEditable.bind(this));
            this.$isConnector.change(this.addInfoForm.bind(this));
        },
        makeEditable: function () {
            this.$saveButton.show();
            this.$editButton.hide();
            this.$Elements.removeClass("EditUserInput");
            this.$Elements.removeAttr("readonly");
            this.$selectInputs.removeAttr("disabled");
            this.$input.prop('disabled', false).trigger("chosen:updated");

        },
        genderSelect: function (userInfo) {
            if (userInfo.gender == "Male") {
                this.$gender.val("Male");
            } else {
                this.$gender.val("Female");
            }
        },
        isConnector: function (userInfo) {
            if (userInfo.connectorStatus == true) {
                this.$isConnector.prop("checked", true);
                this.addInfoForm();
            }
        },
        addInfoForm: function () {
            if (this.$isConnector.is(":checked")) {
                this.$infoForm.show();
            }
            else {
                this.$infoForm.hide();
            }
        },
        addLanguages: function (userLanguages) {
            $.each(userLanguages, function (i, item) {
                $('#lang-' + item.id).attr('selected', true);
            });
            this.$input.trigger("chosen:updated");
        },
        addNationalities: function (userNationalities) {
            $.each(userNationalities, function (i, item) {
                $('#nation-' + item.id).attr('selected', true);
            });
            this.$input.trigger("chosen:updated");
        }
    }
var user = {
    userInfo: {},
    init: function () {
        this.getUser();
    },
    getUser: function () {
        $.ajax({
            type: "GET",
            url: '/api/Users',
            success: (function (response) {
                this.userInfo = response;
                inputElements.isConnector(this.userInfo);
                inputElements.genderSelect(this.userInfo);
                this.getLanguages(this.userInfo.id);
            }).bind(this)
        })
    },
    getLanguages: function (userId) {
        $.ajax({
            type: "GET",
            url: '/api/Languages?id=' + userId,
            success: function (response) {
                inputElements.addLanguages(response);
            }
        })
    },
    getNationalities: function (userId) {
        $.ajax({
            type: "GET",
            url: '/api/Nationalities?id=' + userId,
            success: function (response) {
                inputElements.addNationalities(response);
            }
        })
    } 
}
var selectInputs = {
    init: function () {
        this.cacheDOM();
        this.style();
    },
    cacheDOM: function () {
        this.$inputLangs = $(".langs");
        this.$inputNations = $(".nations");
    },
    style: function () {
        this.$inputLangs.chosen({
            width: "100%"
        });
        this.$inputLangs.prop('disabled', true).trigger("chosen:updated");

        this.$inputNations.chosen({
            width : "100%"
        });
        this.$inputNations.prop('disabled', true).trigger("chosen:updated");
    }
}
inputElements.init();
user.init();
selectInputs.init();
}) ();


