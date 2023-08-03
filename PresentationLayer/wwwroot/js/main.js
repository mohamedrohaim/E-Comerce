var text = "Backend Developer By Profession, Problem Solver By Nature .";
var delay = 100;
var recursiveDelay = 3000;
var element = document.getElementById("typing-text");
var indicator = document.getElementById("typing-indicator");
var index = 0;

function typeText() {
  if (index < text.length) {
    indicator.style.display = "inline";
    element.innerHTML += text.charAt(index);
    index++;
    setTimeout(typeText, delay);
  } else {
    indicator.style.visibility = "hidden"; 
    setTimeout(startTypingAgain, recursiveDelay);
  }
}
function startTypingAgain() {
    element.innerHTML = ""; 
    indicator.style.visibility = "visible"; 
    index = 0; 
    typeText(); 
  }
window.onload = function() {
  indicator.style.display = "inline"; 
  typeText();
};
