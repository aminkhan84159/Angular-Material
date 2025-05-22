import { Component, inject } from '@angular/core';
import { ProductDetailServiceService } from '../../Service/product-detail-service.service';
import { IProductDetail } from '../Models/productDetail.model';
import { ActivatedRoute } from '@angular/router';
import { ProductServiceService } from '../../Service/product-service.service';
import { IProduct } from '../Models/product.model';
import {MatDividerModule} from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-view-product',
  imports: [MatDividerModule,
            MatFormFieldModule

  ],
  templateUrl: './view-product.component.html',
  styleUrl: './view-product.component.css'
})
export class ViewProductComponent {

  productDetailService = inject(ProductDetailServiceService);
  productService = inject(ProductServiceService)
  activatedRoute = inject(ActivatedRoute);
  productDetails : IProductDetail | any = [];
  product : IProduct | any = []

  productId : any = this.activatedRoute.snapshot.paramMap.get('id')

  ngOnInit() {
    this.productDetailService.getProductDetails(this.productId).subscribe((res: any) => {
      this.productDetails = res;
      console.log(this.productDetails)
    });

    this.productService.getProductById(this.productId).subscribe((res: any) => {
      this.product = res;
    });
  }
}
