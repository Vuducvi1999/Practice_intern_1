import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductServices } from 'src/app/services/product.services';

@Component({
  selector: 'app-card-product',
  templateUrl: './card-product.component.html',
  styleUrls: ['./card-product.component.scss'],
})
export class CardProductComponent implements OnInit {
  @Input() image = '';
  @Input() name = '';
  @Input() quantity = '';
  @Input() id = '';
  @Output() updateList = new EventEmitter();

  url = 'https://localhost:44376/api/image';

  constructor(private _service: ProductServices) {}

  ngOnInit(): void {}

  Delete(id: string): void {
    this._service
      .deleteProduct(id)
      .toPromise()
      .then((data) => this.updateList.emit())
      .catch((e) => {});
  }
}
