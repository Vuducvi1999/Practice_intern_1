import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { ListProductComponent } from './pages/list-product/list-product.component';
import { UpdateProductComponent } from './pages/update-product/update-product.component';
import { DetailProductComponent } from './pages/detail-product/detail-product.component';
import { CreateProductComponent } from './pages/create-product/create-product.component';
import { CardProductComponent } from './components/card-product/card-product.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundPageComponent,
    ListProductComponent,
    DetailProductComponent,
    CreateProductComponent,
    UpdateProductComponent,
    CardProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
