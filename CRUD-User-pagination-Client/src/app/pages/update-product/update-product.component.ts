import { Component, OnDestroy } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductServices } from 'src/app/services/product.services';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.scss'],
})
export class UpdateProductComponent implements OnDestroy {
  sub: any;
  UpdateForm = this.fb.group({
    Name: [''],
    Quantity: [''],
    ImageFile: [''],
  });
  message = '';
  messageErr = '';
  error = false;
  token = localStorage.getItem('token') + '';

  constructor(
    private fb: FormBuilder,
    private _service: ProductServices,
    private route: ActivatedRoute
  ) {}

  ChangeFile(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.UpdateForm.get('ImageFile')?.setValue(file);
    }
  }

  Submit() {
    var formData: FormData = new FormData();
    formData.append('Name', this.UpdateForm.get('Name')?.value);
    formData.append('Quantity', this.UpdateForm.get('Quantity')?.value);
    formData.append('ImageFile', this.UpdateForm.get('ImageFile')?.value);

    const id = this.route.snapshot.paramMap.get('id') + '';

    this.sub = this._service.update(id, formData).subscribe(
      (data) => {
        this.message = 'Update success!';
        console.log(data);
      },
      (err) => {
        console.log(err);
        this.message = 'Update fail!';

        if (err.status === 401) {
          this.error = true;
          this.messageErr = '401 - Authorization';
        }
      }
    );
  }

  ngOnDestroy() {
    if (this.sub) this.sub.unsubscribe();
  }
}
