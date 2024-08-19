function load() {

    var banner = document.getElementById("pos-article-text-card-95690");
    banner.click();
    console.log(banner.innerHTML);
    var testlink = banner.innerHTML;


    var shit = document.querySelector("a.yn-item-link");
    console.log(shit);
    var link = shit.getAttribute('href');
    console.log(link);
   /* window.open(link);*/


  //document.querySelectorAll("div#pos-article-text-card-95690");
  //  //var main = test.innerHTML;
  //  //console.log(main);
  //  for (var i = 0; i < shit.length; i++) {
  //      shit[i].click();
  //  }

    

};

