const btn = document.getElementById("trainingBtn");
const menu = document.getElementById("trainingMenu");

btn.addEventListener("click", () => {
    menu.classList.toggle("hidden");
});

document.addEventListener("click", (e) => {
    if (!btn.contains(e.target) && !menu.contains(e.target)) {
        menu.classList.add("hidden");
    }
});