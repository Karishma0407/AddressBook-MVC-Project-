function AlertManager(HolderID) {
    this.DivHolderID = HolderID;
    this.FadeOutTime = 2000;
    this.TimeOut = 2000;

    this.ShowSuccessMessage = function (Message) {
        this.Reset();
        var RepMsg = this.SuccessTemplate;
        if (Message != null)
            RepMsg = RepMsg.replace('#MSG#', Message);
        var MsgObj = $(RepMsg);
        $('#' + this.DivHolderID).append(MsgObj);
        setTimeout(function () {
            $(MsgObj).fadeOut(this.FadeOutTime);
        }, this.TimeOut)
    };

    this.ShowErrorMessage = function (Message) {
        this.Reset();
        var RepMsg = this.ErrorTemplate;
        if (Message != null)
            RepMsg = RepMsg.replace('#MSG#', Message);
        var MsgObj = $(RepMsg);
        $('#' + this.DivHolderID).append(MsgObj);
        setTimeout(function () {
            $(MsgObj).fadeOut(this.FadeOutTime);
        }, this.TimeOut)
    };

    this.ShowNoDataMessage = function (Message) {
        this.Reset();
        var RepMsg = this.NoDataTemplate;
        if (Message != null)
            RepMsg = RepMsg.replace('#MSG#', Message);
        var MsgObj = $(RepMsg);
        $('#' + this.DivHolderID).append(MsgObj);
        setTimeout(function () {
            $(MsgObj).fadeOut(this.FadeOutTime + 10000);
        }, this.TimeOut+5000)
    };

    this.Reset = function () {
        $('#' + this.DivHolderID).html('');
    },

    this.SuccessTemplate = '<div class="alert alert-success alert-dismissible fade in" role="alert">' +
                               '<span class="glyphicon glyphicon-ok"></span>' +
                               '<span> #MSG#</span>' +
                               '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                               '<span aria-hidden="true">&times;</span>' +
                               '</button>' +
                               '</div>';
    this.ErrorTemplate = '<div class="alert alert-danger alert-dismissible fade in" role="alert">' +
                               '<span class="glyphicon glyphicon-ban-circle"></span>' +
                               '<span> #MSG#</span>' +
                               '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                               '<span aria-hidden="true">&times;</span>' +
                               '</button>' +
                               '</div>';
    this.NoDataTemplate = '<div class="alert alert-info  alert-dismissible fade in" role="alert">' +
                              '<span class="glyphicon glyphicon-info-sign"></span>' +
                              '<span> #MSG#</span>' +
                              '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                              '<span aria-hidden="true">&times;</span>' +
                              '</button>' +
                              '</div>';
}