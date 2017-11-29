// Main script for FileManagerController. Allows update view by ajax.

// get container from dom
var $container = $("#file-browser");

var currentDir;

// get path of current dir
function getPath() {
    return currentDir.CurrentDir.FullPath;
}

// get name of current dir
function getName() {
    return currentDir.CurrentDir.Name;
}

// callback for ajax request
function onServerResponse(serverData) {

    // clear container
    $container.empty();

    // define current dir object 
    currentDir = serverData;

    // render dirbar
    renderDirbar();

    // render dirs and files
    renderFiles(currentDir.ChildDirs);
    renderFiles(currentDir.ChildFiles);

    // add click listner for each file-link dom element
    $(".file-link").click(function (e) {
        // disable default click event
        e.preventDefault();

        // get file name
        var name = $(this).html();

        // get file path
        var fullPath = $.grep(currentDir.ChildDirs, function (item, i) {
            return item.Name === name;
        })[0].FullPath;

        // ajax dir child elements
        $.post("/FileManager/GetDirElements", { path: fullPath }, onServerResponse, "json");
    });
}

// render directory file list
function renderFiles(array) {
    for (var i = 0; i < array.length; i++) {

        // get file info object
        var fileInfo = array[i];

        // create render object
        var $file = $("<a />").text(fileInfo.Name).addClass("file-link").attr("href", "");

        // adding renderer to container
        $container.append("<tr><td>" + $("<div />").append($file).html() + "</td></tr>");
    }
}

// render directory path navigation
function renderDirbar() {

    var path = getPath();
    var name = getName();
    var dirs;
    var $dirbar = $("#dirbar");
    var dirItemPath = "";

    $dirbar.empty();

    // TODO: move parsing to server side
    // parse string path in to array
    if (path == "root") {
        dirs = [name];
    } else {
        dirs = path.split("\\");
    }

    // render each dir in path
    dirs.forEach(function (dir, i, arr) {

        if (dir === "")
            return;

        if (path == "root")
            dirItemPath = "root";
        else
            dirItemPath += dir + "\\";

        var $dirbarItem = $("<div />").addClass("dirbar-item").text(dir).attr("path", dirItemPath);

        $dirbar.append($dirbarItem);
    });

    //add onClick listner
    $(".dirbar-item").click(function () {

        var dirPath = $(this).attr("path");

        // ajax dir child elements
        $.post("/FileManager/GetDirElements", { path: dirPath }, onServerResponse, "json");
    });
}

// on document ready
$(function () {

    // ajax root elements
    $.post("/FileManager/GetDirElements", { path: "root" }, onServerResponse, "json");
});