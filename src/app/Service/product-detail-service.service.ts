import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IProductDetail } from '../Components/Models/productDetail.model';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailServiceService {

  constructor() { }

  mainApi = 'http://localhost:5253/api/'
  http = inject(HttpClient)

  public getProductDetails(id: number) {
    return this.http.get(`${this.mainApi}ProductDetail/GetProductDetailByProductId?productId=${id}`)
  }

  public addProductDetail(productDetail: IProductDetail) {
    return this.http.post(`${this.mainApi}ProductDetail/AddProductDetail`, productDetail)
  }

  public updateProductDetail(productDetail: IProductDetail) {
    return this.http.put(`${this.mainApi}ProductDetail/UpdateProduct`, productDetail)
  }
}
