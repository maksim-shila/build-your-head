import styles from "./avatar-upload.module.css";

export const AvatarUpload = () => {
    return (
        <div className={styles.container} onClick={_ => console.log("Upload!")}>
            <button className={styles.plusButton} onClick={e => e.preventDefault()} />
        </div>
    );
}