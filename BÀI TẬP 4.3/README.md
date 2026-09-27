# BÀI TẬP 4.3: FORM CALCULATOR DÙNG CHUNG SỰ KIỆN VỚI SENDER

Chương trình ứng dụng Máy tính đơn giản (Calculator) minh họa kỹ thuật tối ưu lập trình sự kiện WinForms bằng cách sử dụng **1 Event Handler** chung cho 10 nút bấm số dựa trên tham số `object sender`.

---

## 📸 Màn Hình Demo Giao Diện

![Giao diện Calculator](<./BÀI TẬP 4.3/demo.png>)

---

## 🛠️ Các Control & Thuộc Tính Sử Dụng

| Tên Control | Tên Variable `(Name)` | Thuộc tính/Cấu hình chính |
| :--- | :--- | :--- |
| **TextBox** | `txtDisplay` | `Text = "0"`, `RightToLeft = Yes`, `ReadOnly = True` |
| **Button (0-9)** | `btn0` đến `btn9` | Gán chung sự kiện `NumberButton_Click` |
| **Button (+,-,*,/)**| `btnAdd`, `btnSub`, `btnMul`, `btnDiv` | Gán chung sự kiện `OperationButton_Click` |
| **Button (=)** | `btnEqual` | Xử lý tính toán theo phép toán đã lưu |
| **Button (Clear)** | `btnClear` | `Text = "C"` - Xóa toàn bộ phép tính về 0 |

---

## 🚀 Chức Năng Chính & Kỹ Thuật Nổi Bật

1. **Ủy quyền sự kiện qua `object sender`**:
   - Sử dụng hàm ép kiểu `Button btn = (Button)sender;` để xác định chính xác nút vừa bấm.
   - Giúp tiết kiệm dung lượng code, tránh lặp lại 10 sự kiện `Click` riêng lẻ cho từng nút số.
2. **Xử lý phép toán cơ bản**:
   - Thực hiện 4 phép tính: Cộng, Trừ, Nhân, Chia.
   - Tự động kiểm tra và cảnh báo lỗi chia cho 0 bằng `MessageBox`.

---

## 💻 Cách Chạy Dự Án

1. Clone dự án về máy:
   ```bash
   git clone [https://github.com/minhnvn24810320314/BAI_TAP_4_3.git](https://github.com/minhnvn24810320314/BAI_TAP_4_3.git)