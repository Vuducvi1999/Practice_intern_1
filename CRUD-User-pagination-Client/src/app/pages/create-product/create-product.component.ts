import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductServices } from 'src/app/services/product.services';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss'],
})
export class CreateProductComponent implements OnDestroy {
  sub: any;
  UpdateForm = this.fb.group({
    Name: ['', Validators.required],
    Quantity: ['', Validators.required],
    ImageFile: ['', Validators.required],
  });
  message = '';
  error = false;
  messageErr = '';

  constructor(private fb: FormBuilder, private _service: ProductServices) {}

  ChangeFile(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.UpdateForm.get('ImageFile')?.setValue(file);
    }
  }

  Submit() {
    this.message = '';

    const formData = new FormData();
    formData.append('Name', this.UpdateForm.get('Name')?.value);
    formData.append('Quantity', this.UpdateForm.get('Quantity')?.value);
    formData.append('ImageFile', this.UpdateForm.get('ImageFile')?.value);

    this.sub = this._service.create(formData).subscribe(
      (data) => {
        this.message = 'Create success!';
      },
      (err) => {
        console.log(err);
        this.message = 'Create fail!';

        if (err.status === 401) {
          this.messageErr = '401 - Authorization';
          this.error = true;
        }
      }
    );
  }

  ngOnDestroy() {
    if (this.sub) this.sub.unsubscribe();
  }
}
