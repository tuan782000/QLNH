// Hàm chuyển đổi ngày tháng
export const formatDate = dateStr => {
    const date = new Date(dateStr);
    const weekdays = [
        'Chủ nhật',
        'Thứ 2',
        'Thứ 3',
        'Thứ 4',
        'Thứ 5',
        'Thứ 6',
        'Thứ 7'
    ];
    const dayOfWeek = weekdays[date.getDay()];
    const day = date.getDate();
    const month = date.getMonth() + 1; // Tháng bắt đầu từ 0
    const year = date.getFullYear();
    return `${dayOfWeek}, ${day}/${month}/${year}`;
};
