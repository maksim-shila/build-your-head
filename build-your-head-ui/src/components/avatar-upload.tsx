import React, { ChangeEvent } from "react";
import styles from "./avatar-upload.module.css";

export const AvatarUpload = () => {

    const [imageName, setImageName] = React.useState<string>();
    const [imageUrl, setImageUrl] = React.useState<string | null>(null);

    const onChange = (event: ChangeEvent<HTMLInputElement>) => {
        const files = event.target.files;
        if (files == null) {
            return;
        }

        const file = files[0];
        if (file == null) {
            return;
        }

        setImageName(file.name);
        setImageUrl(URL.createObjectURL(file));
    }

    return (
        <label className={styles.container}>
            {imageUrl ?
                <div className={styles.imageContainer}>
                    <img className={styles.image} src={imageUrl} alt={imageName} />
                </div>
                :
                <span className={styles.plusButton} />
            }
            <input hidden type="file" accept=".jpg, .jpeg, .png" onChange={onChange} />
        </label>
    );
}