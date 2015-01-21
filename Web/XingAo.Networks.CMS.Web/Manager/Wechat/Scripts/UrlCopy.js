$(document).ready(function ()
{
    $('a#copy-dynamic').zclip({
        path: '/Images/ZeroClipboard.swf',
        copy: function () { return $('input#dynamic').val(); }
    });
});

