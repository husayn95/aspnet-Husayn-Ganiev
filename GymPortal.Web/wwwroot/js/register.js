(function () {
  document.addEventListener("DOMContentLoaded", function () {

    const pwd = document.getElementById("passwordInput");
    const toggle = document.getElementById("togglePassword");
    const strengthBar = document.getElementById("passwordStrength");
    const strengthText = document.getElementById("passwordStrengthText")?.querySelector("span");
    const rulesList = document.getElementById("passwordRules");

    if (toggle && pwd) {
      toggle.addEventListener("click", function () {
        const type = pwd.type === "password" ? "text" : "password";
        pwd.type = type;
        toggle.textContent = type === "password" ? "Show" : "Hide";
      });
    }

    function calcStrength(value) {
      let score = 0;
      if (!value) return 0;
      if (value.length >= 6) score += 20;
      if (value.length >= 8) score += 20;
      if (/[A-Z]/.test(value)) score += 20;
      if (/[0-9]/.test(value)) score += 20;
      if (/[^A-Za-z0-9]/.test(value)) score += 20;
      return score;
    }

    function updateRules(value) {
      if (!rulesList) return;

      const rules = {
        length: value.length >= 6,
        digit: /\d/.test(value),
        uppercase: /[A-Z]/.test(value),
        symbol: /[^A-Za-z0-9]/.test(value),
      };

      rulesList.querySelectorAll(".rule").forEach(el => {
        const rule = el.getAttribute("data-rule");
        if (rule) {
          el.style.color = rules[rule] ? "green" : "red";
        }
      });
    }

    if (pwd) {
      pwd.addEventListener("input", function (e) {
        const value = e.target.value;

        const score = calcStrength(value);
        updateRules(value);

        if (strengthBar) {
          strengthBar.style.width = score + "%";
        }

        if (strengthText) {
          strengthText.textContent = score + "%";
        }
      });
    }

  });
})();