let isLocked = document.querySelector(".lock-status");

isLocked.innerHTML = localStorage.getItem("state");
if (isLocked.innerHTML == "") {
    isLocked.innerHTML = "Locked";
}