```mermaid
erDiagram
    brand ||--o{ product : contains
    category ||--o{ product: contains

    product {
        UUID id
        VARCHAR name
        VARCHAR description
        VARCHAR sku
        BIGINT quantity
        UUID brand_id
        UUID category_id
        TIMESTAMP created_at
        TIMESTAMP updated_at
    }

    brand {
        UUID id
        VARCHAR name 
        TIMESTAMP created_at
        TIMESTAMP updated_at
    }

    category {
        UUID id 
        VARCHAR name
        TIMESTAMP created_at
        TIMESTAMP updated_at
    }
```