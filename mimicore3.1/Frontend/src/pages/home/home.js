function getComponent() {
  const myComp = document.createElement('input');
  myComp.type = 'button';
  myComp.value = 'Click me to test';
  myComp.onclick = () => {
    alert('The Home page is comming soon!');
  };
  console.log(myComp);
  return myComp;
}

const newBtn = getComponent();
document.body.appendChild(newBtn);
