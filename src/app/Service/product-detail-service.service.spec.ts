import { TestBed } from '@angular/core/testing';

import { ProductDetailServiceService } from './product-detail-service.service';

describe('ProductDetailServiceService', () => {
  let service: ProductDetailServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductDetailServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
