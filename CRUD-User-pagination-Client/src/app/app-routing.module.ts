import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateProductComponent } from './pages/create-product/create-product.component';
import { DetailProductComponent } from './pages/detail-product/detail-product.component';
import { HomeComponent } from './pages/home/home.component';
import { ListProductComponent } from './pages/list-product/list-product.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { UpdateProductComponent } from './pages/update-product/update-product.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home',
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'product/page/:index',
    component: ListProductComponent,
  },
  {
    path: 'product/create',
    component: CreateProductComponent,
  },
  {
    path: 'product/update/:id',
    component: UpdateProductComponent,
  },
  {
    path: 'product/:id',
    component: DetailProductComponent,
  },
  {
    path: '**',
    component: NotFoundPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
