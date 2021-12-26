let lock = document.querySelector(".lock-car");
let unlock = document.querySelector(".unlock-car");
let lights = document.querySelector(".lights");
let honk = document.querySelector(".honk");
let preheating = document.querySelector(".preheating");
let logout = document.querySelector(".logout");

lock.addEventListener("click", () => {
    let shouldLockCar = confirm("Are you sure that you want to lock your car?");
    if(shouldLockCar)
    {
        alert("Successfully locked the car!");
    }
});

unlock.addEventListener("click", () => {
    let shouldUnlockCar = confirm("Are you sure that you want to unlock your car?");
    if(shouldUnlockCar)
    {
        alert("Successfully unlocked the car!");
    }
});

honk.addEventListener("click", () => {
    let shouldHonk = confirm("Are you sure that you want to honk?");
    if(shouldHonk)
    {
        alert("Successfully honked!");
    }
});

lights.addEventListener("click", () => {
    let shouldFlashlights = confirm("Are you sure that you want to flashlight now?");
    if(shouldFlashlights)
    {
        alert("Successfully flashlighted!");
    }
});

preheating.addEventListener("click", () => {
    let shouldPreheat = confirm("Are you sure that you want preheat your car?");
    if(shouldPreheat)
    {
        alert("Successfully preheated the car!");
    }
});

//logout.addEventListener("click", () => {
//    let shouldLogOut = confirm("Are you sure that you want to logout?");
//    if (shouldLogOut)
//    {
//        let logoutUrl = "/Login/Login";
//        window.location.href = logoutUrl;
//    }
//});