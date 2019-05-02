import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ProductService } from './products/product.service';
import { RouterModule } from '@angular/router';

//IN ORDER FOR ANGULAR TO WORK, THE LAYOUT PAGE MUS HAVE THE FOLLOWING HTML TAG BELOW:
// <base href="/">
//OTHERWISE IT'LL GIVE AN ERROR ABOUT NOT PROVIDING BASE HREF.
//PLEASE LOOK AT THE LAYOUT PAGE INSIDE THE HEADER TAG
//https://www.youtube.com/watch?v=Std1QJpMEiE

//AFTER YOU BUILD THE ANGULAR APPLICATION, MOVE THE DIST FOLDER CONTAINING THE JS FILES TO THE WWWWROOT FOLDER
//IN ORDER FOR THE CHANGES TO BE REFLECTED IN THE WEB BROWSER, MAKE SURE TO CLEAN AND REBUILD THE COMPILER, CLEAR BROWSING DATA IN YOUR WEB BROWSER
//AND THEN CLEAR ALL BREAKPOINTS IN THE WEB BROWSER

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
