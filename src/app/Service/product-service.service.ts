import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IProduct } from '../Components/Models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  constructor() { }

  mainApi = 'http://localhost:5253/api/'
  http = inject(HttpClient)

  public getProducts() {
    return this.http.get(`${this.mainApi}Product/GetAllProducts`)
  }

  public getFilteredProducts(searchText: string) {
    return this.http.get(`${this.mainApi}Product/FilteredProduct?search=${searchText}`)
  }

  public getProductById(id: number) {
    return this.http.get(`${this.mainApi}Product/GetProductById?productId=${id}`)
  }

  public addProduct(product: IProduct) {
    return this.http.post(`${this.mainApi}Product/AddProduct`,product)
  }

  public deleteProduct(id: number) {
    return this.http.delete(`${this.mainApi}Product/DeleteProduct?productId=${id}`)
  }

  public updateProduct(product: IProduct) {
    return this.http.put(`${this.mainApi}Product/UpdateProduct`, product)
  }


}
