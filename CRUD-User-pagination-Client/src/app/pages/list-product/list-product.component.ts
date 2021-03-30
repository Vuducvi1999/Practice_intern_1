import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductServices } from 'src/app/services/product.services';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss'],
})
export class ListProductComponent implements OnInit, OnDestroy {
  products: any[] = [];
  error = false;
  message = '';
  sub: any;
  totalPagesArray: any[] = [];

  constructor(
    private _service: ProductServices,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe(() => {
      this.getList();
    });
  }

  getList(): void {
    if (this.sub) this.sub.unsubscribe();

    let index: any = this.route.snapshot.paramMap.get('index');
    index = index ? Number(index) : 1;

    console.log(index);

    this.sub = this._service.getPage(index).subscribe(
      (data) => {
        this.products = data.data.map((i) => {
          i.image = i.image.replace('Upload', '');
          return i;
        });

        this.totalPagesArray = [...Array(data.totalPages).keys()].map(
          (i) => i + 1
        );
      },
      (err) => {
        this.error = true;
        if (err.status === 401) this.message = '401 - Authorization';
      }
    );
  }

  ngOnInit(): void {
    this.getList();
  }

  ngOnDestroy() {
    if (this.sub) this.sub.unsubscribe();
  }

  Rerender() {
    this.getList();
  }

  navigateToPage(page: number) {
    this.router.navigate(['/product/page', page]).then().catch();
  }
}
