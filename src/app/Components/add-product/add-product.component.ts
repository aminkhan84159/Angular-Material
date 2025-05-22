import { Component, Inject, inject } from '@angular/core';
import { IProduct } from '../Models/product.model';
import { IProductDetail } from '../Models/productDetail.model';
import { ProductServiceService } from '../../Service/product-service.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { ProductDetailServiceService } from '../../Service/product-detail-service.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-add-product',
  imports: [MatFormFieldModule,
            MatInputModule,
            MatButtonModule,
            FormsModule,
            MatSelectModule,
            MatStepperModule,
            MatIconModule,
            MatDialogModule
  ],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {

  product: IProduct | any = {}
  productDetail: IProductDetail | any = {}
  productService = inject(ProductServiceService)
  productDetailService = inject(ProductDetailServiceService)

  exist: boolean = false

  constructor(@Inject(MAT_DIALOG_DATA) public data: null | any) {
    this.product.productId = data.Id
  }

  ngOnInit(): void{
    console.log(this.product.productId)
    if(this.product.productId == null) {
      this.productDetail = {}
      this.product = {}
    }else{
      this.productService.getProductById(this.product.productId).subscribe((res: any) => {
        this.product = res
        this.exist = true
      })

      this.productDetail.productId = this.product.productId
      this.productDetailService.getProductDetails(this.product.productId).subscribe((res: any) => {
        this.productDetail = res
      })
    }

  }

  addProduct(){
    this.productService.addProduct(this.product).subscribe((res: any) => {
      
    })
  }

  addProductDetail(){
    this.productDetail.productId = this.product.productId
    this.productDetailService.addProductDetail(this.productDetail).subscribe((res: any) => {
      
      alert("Product Added Successfully");
    })
  }

  updateProduct(){
    this.productService.updateProduct(this.product).subscribe((res: any) => {
      console.log(res)
    })
  }

  updateProductDetail(){
    this.productDetail.productId = this.product.productId
    this.productDetailService.updateProductDetail(this.productDetail).subscribe((res: any) => {
      console.log(res)
      alert("Product Updated Successfully")
    })
  }
}
