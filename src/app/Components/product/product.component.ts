import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { ProductServiceService } from '../../Service/product-service.service';
import { IProduct } from '../Models/product.model';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CdkTableModule } from '@angular/cdk/table';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddProductComponent } from '../add-product/add-product.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from'@angular/material/input'
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-product',
  imports: [MatTableModule,
            MatMenuModule,
            MatIconModule,
            MatButtonModule,
            CdkTableModule,
            MatDialogModule,
            MatFormFieldModule,
            MatIconModule,
            MatSelectModule,
            MatInputModule,
            FormsModule,
            CommonModule
            ],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  productService = inject(ProductServiceService)
  products : IProduct | any = []
  readonly dialog = inject(MatDialog) 
  router = inject(Router)

  searchText: string = ''
  currencyType: string = ''

  displayedColumns: string[] = ['No','title', 'category', 'price', 'brand','info']

  ngOnInit() {
    this.productService.getProducts().subscribe((res: any) => {
      this.products = res;
      console.log(this.products)
    })
  }

  addProduct(id: number | null){
    const dialogRef = this.dialog.open(AddProductComponent,{
      data : {Id : id},
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  viewProduct(id: number) {
    this.router.navigate([`viewProduct/${id}`]);
  }

  filterproducts(searchText: string) {
    if(searchText == '') {
      this.productService.getProducts().subscribe((res: any) => {
        this.products = res;
      });
    }else{
      this.productService.getFilteredProducts(searchText).subscribe((res: any) => {
        this.products = res;
      });
   }
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe((res: any) => {
      this.products = res;
      alert("Product Deleted Successfully")
    })
  }

  options = [
    { name: "USD", currencyRate: 1 },
    { name: "INR", currencyRate: 84.32 },
    { name: "PND", currencyRate: 0.75 },
  ]

  convertWithCurrencyRate(value: number, currency: string){
    let currencyRate = this.options.find(x => x.name === currency)?.currencyRate;
    if (currencyRate)
      return value * currencyRate;
    
    return value;
  }
}
