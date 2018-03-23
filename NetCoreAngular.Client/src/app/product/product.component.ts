import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/services';
import { Product } from '../../models/models';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent {

  product: Product[];

  constructor(productService: ProductService) {
    productService.getProduct().subscribe(data => this.product = data);
  }

}
