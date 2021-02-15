<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestVideo.aspx.cs" Inherits="Pertamina.CORSEC._2019.TestVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--<link href="http://vjs.zencdn.net/7.0/video-js.min.css" rel="stylesheet">
    <script src="http://vjs.zencdn.net/7.0/video.min.js"></script>--%>

    <link href="<%: ResolveUrl("~/Content/video/video-js.min.css") %>" rel="stylesheet" />
    <script src="<%: ResolveUrl("~/Content/video/video.min.js") %>"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<video id="example_video_1" class="video-js" controls preload="none" width="640" height="264" poster="http://vjs.zencdn.net/v/oceans.png" data-setup="{}">
                <source src="http://vjs.zencdn.net/v/oceans.mp4" type="video/mp4">
                <source src="http://vjs.zencdn.net/v/oceans.webm" type="video/webm">
                <source src="http://vjs.zencdn.net/v/oceans.ogv" type="video/ogg">
                <track kind="captions" src="../shared/example-captions.vtt" srclang="en" label="English">
                <track kind="subtitles" src="../shared/example-captions.vtt" srclang="en" label="English">
                <p class="vjs-no-js">To view this video please enable JavaScript, and consider upgrading to a web browser that <a href="https://videojs.com/html5-video-support/" target="_blank">supports HTML5 video</a></p>
            </video>--%>
            <video id="example_video_1" class="video-js" controls preload="auto"  width="640" height="264" poster="Content/video/oceans.png" data-setup="{}" >

                <source src="Content/video/oceans.mp4" type="video/mp4" />
                <source src="Content/video/oceans.webm" type="video/webm" />
                <source src="Content/video/oceans.ogv" type="video/ogg" />
            </video>

        </div>
    </form>
</body>
</html>

