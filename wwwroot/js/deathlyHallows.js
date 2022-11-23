// create connection
var connectDeathlyHallows = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/deathlyHallows")
    .build();

// connect to methods that hub invokes aka receive notifications from hub
var cloakSpan = document.getElementById("cloakCounter");
var stoneSpan = document.getElementById("stoneCounter");
var wandSpan = document.getElementById("wandCounter");

var drawCount = (cloak, stone, wand) => {
    cloakSpan.innerText = cloak;
    stoneSpan.innerText = stone;
    wandSpan.innerText = wand;
};

connectDeathlyHallows.on("updateDeathlyHallowsCount", drawCount);

// invoke hub methods aka send notification to hub


// start connection

var fulfilled = () => {
    console.log("Connection established for deathlyHallows successfully");
    connectDeathlyHallows.invoke("getRaceStatus")
        .then(raceCounter => drawCount(raceCounter.cloak, raceCounter.stone, raceCounter.wand));
};

var rejected = () => console.log("Connection rejected");

connectDeathlyHallows.start().then(fulfilled, rejected);
