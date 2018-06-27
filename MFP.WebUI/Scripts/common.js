
var common={
    openNewTab:function(layId, title, url) {
        window.parent.openNewTab(layId, title, url);

    },
    closeTab: function (layId) {
        window.parent.closeTab(layId);
    }
}