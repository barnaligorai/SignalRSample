// create connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

// connect to methods that hub invokes aka receive notifications from hub
connectionUserCount.on("updatedTotalViews", value => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    console.log(value);
    newCountSpan.innerText = value;
});

connectionUserCount.on("updatedTotalUsers", value => {
    var newUserSpan = document.getElementById("totalUsersCounter");
    console.log(value);
    newUserSpan.innerText = value;
});

// invoke hub methods aka send notification to hub
newWindowLoadedOnClient = () => {
    connectionUserCount.send("NewWindowLoaded");
};

// start connection
fulfilled = () => {
    console.log("Connection established successfully");
    newWindowLoadedOnClient();
};

rejected = () => console.log("Connection rejected");

connectionUserCount.start().then(fulfilled, rejected);
