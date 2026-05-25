mergeInto(LibraryManager.library, {

    InitYSDKExtern : function(id)
    {
        initSDK(id);
    },

    SaveDataExtern : function(date)
    {
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        player.setData(myobj);
        console.log('Save data');
    },

    LoadDataExtern : function()
    {
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            gameInstance.SendMessage('SDK', 'AcceptLoadedData', myJSON);
            console.log('Load data');
        });
    },

    ShowRewardedVideoExtern : function(id) 
    {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    gameInstance.SendMessage('SDK', 'StopGame');
                    console.log('Video ad open.');
                },
                onRewarded: () => {
                    gameInstance.SendMessage('SDK', 'InvokeCallback', id);
                    console.log('Rewarded!');
                },
                onClose: () => {
                    gameInstance.SendMessage('SDK', 'ContinueGame');
                    console.log('Video ad closed.');
                }, 
                onError: (e) => {
                    gameInstance.SendMessage('SDK', 'ContinueGame');
                    console.log('Error while open video ad:', e);
                }
            }
        })
    },

    ShowFullscreenAdvExtern : function () 
    {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    gameInstance.SendMessage('SDK', 'ContinueGame');
                    console.log ("adv close");
                },
                onOpen: function(open) {
                    gameInstance.SendMessage('SDK', 'StopGame');
                    console.log ("adv open");
                },
                onError: function(error) {
                    gameInstance.SendMessage('SDK', 'ContinueGame');
                    console.log ("adv error");
                }
            }
        })
    },

    GetLanguageExtern: function () 
    {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);

        return buffer;
    },

    GameReadyExtern: function ()
    {
        gameReady();
    },
});