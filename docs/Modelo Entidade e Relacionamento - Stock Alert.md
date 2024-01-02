```mermaid
erDiagram
    stock_alert {
        UUID id
        UUID product_id
        BIGINT quantity
        VARCHAR email
        BOOLEAN is_deleted
        TIMESTAMP created_at
        TIMESTAMP updated_at
        TIMESTAMP deleted_at
    }
```